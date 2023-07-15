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

            var polylineworks = input.Overrides.Polylines.CreateElements(
              input.Overrides.Additions.Polylines,
              input.Overrides.Removals.Polylines,
              (add) => new Polylinework(add),
              (polylinework, identity) => polylinework.Match(identity),
              (polylinework, edit) => polylinework.Update(edit)
            );

            var bezierworks = input.Overrides.Beziers.CreateElements(
              input.Overrides.Additions.Beziers,
              input.Overrides.Removals.Beziers,
              (add) => new Bezierwork(add),
              (bezierwork, identity) => bezierwork.Match(identity),
              (bezierwork, edit) => bezierwork.Update(edit)
            );

            if (polylineworks.Count == 0 && bezierworks.Count == 0)
            {
                var offset = 0;
                foreach (var letter in "HYPAR")
                {
                    if (HyparFont.LetterShapes.ContainsKey(letter))
                    {
                        foreach (var shape in HyparFont.LetterShapes[letter])
                        {
                            if (shape is Polyline linework)
                            {
                                var _linework = new Polylinework(linework.TransformedPolyline(new Transform(new Vector3(offset, 0, 0))));
                                polylineworks.Add(_linework);
                            }
                            else if (shape is Bezier bezierwork)
                            {
                                var _bezierwork = new Bezierwork(bezierwork.TransformedBezier(new Transform(new Vector3(offset, 0, 0))));
                                bezierworks.Add(_bezierwork);
                            }
                        }
                        offset += 10;
                    }
                }
            }

            output.Model.AddElements(lineworks);
            output.Model.AddElements(polylineworks);
            output.Model.AddElements(bezierworks);

            List<object> curves = new List<object>();
            curves.AddRange(lineworks);
            curves.AddRange(polylineworks);
            curves.AddRange(bezierworks);
            foreach (var curve in curves)
            {
                if (curve is Polylinework linework)
                {
                    foreach (var segment in linework.Polyline.Segments())
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
                else if (curve is Bezierwork bezierwork)
                {
                    var point = bezierwork.Bezier.PointAt(0.5);
                    var direction = bezierwork.Bezier.NormalAt(0.5);
                    var size = 1;
                    var mass = new Mass(Polygon.Rectangle(size, size), size);
                    var center = mass.Bounds.Center() + new Vector3(0, 0, size / 2.0) + mass.Transform.Origin;
                    mass.Transform = new Transform(-1 * center).Concatenated(new Transform(new Plane(point, direction)));
                    output.Model.AddElement(mass);
                }
            }

            /// CIRCLE
            var circle = new Circle(new Vector3(-10, 5, 0), 4);
            output.Model.AddElement(new Circlework(circle));

            /// ARC
            var arc = new Arc(new Vector3(15, -10, 0), 4, 0.0, 270.0);
            output.Model.AddElement(new Arcwork(arc));

            /// ELLIPSE
            var ellipse = new Ellipse(new Vector3(35, -10, 0), 2, 4);

            var divisions = 40; // Number of divisions for the polyline approximation
            var points = new List<Vector3>();

            for (var i = 0; i <= divisions; i++)
            {
                var t = (double)i / divisions;
                var point = ellipse.PointAt(t * (2 * Math.PI));
                points.Add(point);
            }

            var polylineEllipse = new Polyline(points);

            // Add the polyline to the model
            output.Model.AddElement(new Polylinework(polylineEllipse));

            /// POLYLINE
            var polyline = new Polyline(
                new List<Vector3>()
                {
                    new Vector3(62.5, 10, 0),
                    new Vector3(60, 6.5, 0),
                    new Vector3(61, 6.5, 0),
                    new Vector3(58, 4, 0),
                    new Vector3(59, 4, 0),
                    new Vector3(56, 0, 0),
                    new Vector3(61.5, 4.5, 0),
                    new Vector3(60.5, 4.5, 0),
                    new Vector3(63.5, 7, 0),
                    new Vector3(62.5, 7, 0),
                    new Vector3(65, 10, 0),
                }
            );

            output.Model.AddElement(new Polylinework(polyline));

            /// LINE
            var line = new Line(new Vector3(35, 15, 0), new Vector3(35, 25, 0));
            output.Model.AddElement(new Linework(line));

            /// BEZIER
            var bezier = new Bezier(
                new List<Vector3>()
                {
                    new Vector3(10, 20, 0),
                    new Vector3(15, 30, 0),
                    new Vector3(15, 10, 0),
                    new Vector3(20, 20, 0)
                }
            );

            output.Model.AddElement(new Bezierwork(bezier));

            return output;
        }
    }
}