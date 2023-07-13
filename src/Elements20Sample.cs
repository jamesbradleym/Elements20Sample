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

            output.Model.AddElements(lineworks);

            foreach (var lw in lineworks)
            {
                foreach (var segment in lw.Polyline.Segments())
                {
                    var midpoint = segment.PointAt(0.5 * segment.Length());
                    var direction = segment.Direction();
                    var size = 1;
                    var mass = new Mass(Polygon.Rectangle(size, size), size);
                    var center = mass.Bounds.Center() + new Vector3(0, 0, mass.Height / 2);
                    mass.Transform = new Transform(new Plane(midpoint, direction));
                    output.Model.AddElement(mass);
                }
            }

            return output;
        }
    }
}