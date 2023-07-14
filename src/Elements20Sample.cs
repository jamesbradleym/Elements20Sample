using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace Elements20Sample
{
    public static class Elements20Sample
    {
        /// <summary>
        /// The Elements20Sample function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A Elements20SampleOutputs instance containing computed results and the model with any new elements.</returns>
        public static Elements20SampleOutputs Execute(Dictionary<string, Model> inputModels, Elements20SampleInputs input)
        {
            var output = new Elements20SampleOutputs();

            var lineworks = input.Overrides.Lines.CreateElements(
              input.Overrides.Additions.Lines,
              input.Overrides.Removals.Lines,
              (add) => new Linework(add),
              (linework, identity) => linework.Match(identity),
              (linework, edit) => linework.Update(edit)
            );

            var curveworks = input.Overrides.Curves.CreateElements(
              input.Overrides.Additions.Curves,
              input.Overrides.Removals.Curves,
              (add) => new Curvework(add),
              (curvework, identity) => curvework.Match(identity),
              (curvework, edit) => curvework.Update(edit)
            );

            if (lineworks.Count == 0 && curveworks.Count == 0)
            {
                var offset = 0;
                foreach (var letter in "HYPAR")
                {
                    if (HyparFont.LetterShapes.ContainsKey(letter))
                    {
                        foreach (var shape in HyparFont.LetterShapes[letter])
                        {
                            if (shape is Polyline polyline)
                            {
                                var linework = new Linework(polyline.TransformedPolyline(new Transform(new Vector3(offset, 0, 0))));
                                lineworks.Add(linework);
                            }
                            else if (shape is Bezier bezier)
                            {
                                var curvework = new Curvework(bezier.TransformedBezier(new Transform(new Vector3(offset, 0, 0))));
                                curveworks.Add(curvework);
                            }
                        }
                        offset += 10;
                    }
                }
            }

            output.Model.AddElements(lineworks);
            output.Model.AddElements(curveworks);

            List<object> curves = new List<object>();
            curves.AddRange(lineworks);
            curves.AddRange(curveworks);
            foreach (var curve in curves)
            {
                if (curve is Linework polyline)
                {
                    foreach (var segment in polyline.Polyline.Segments())
                    {
                        var point = segment.PointAt(0.5 * segment.Length());
                        var direction = segment.Direction();
                        var size = 1;
                        var mass = new Mass(Polygon.Rectangle(size, size), size);
                        var center = mass.Bounds.Center() + new Vector3(0, 0, size / 2.0) + mass.Transform.Origin;

                        mass.Transform = new Transform(-1 * center).Concatenated(new Transform(new Plane(point, direction)));

                        output.Model.AddElement(mass);
                    }
                }
                else if (curve is Curvework bezier)
                {
                    var point = bezier.Bezier.PointAt(0.5);
                    var direction = bezier.Bezier.NormalAt(0.5);
                    var size = 1;
                    var mass = new Mass(Polygon.Rectangle(size, size), size);
                    var center = mass.Bounds.Center() + new Vector3(0, 0, size / 2.0) + mass.Transform.Origin;
                    mass.Transform = new Transform(-1 * center).Concatenated(new Transform(new Plane(point, direction)));
                    output.Model.AddElement(mass);
                }
            }

            return output;
        }
    }
}