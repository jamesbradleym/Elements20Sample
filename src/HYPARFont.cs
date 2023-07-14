using Elements.Geometry;
using Elements20Sample;
using System.Collections.Generic;

namespace Elements
{
    public static class HyparFont
    {
        public static Dictionary<char, List<Curve>> LetterShapes = new Dictionary<char, List<Curve>>
        {
            // Define the polylines for each letter
            {
                'H', new List<Curve>
                {
                    // First 4 vertical lines of 'H'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                        new Vector3(0, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(1, 0, 0),
                        new Vector3(1, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(2, 0, 0),
                        new Vector3(2, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 0, 0),
                        new Vector3(3, 10, 0)
                    }),

                    // Horizontal 4 lines of 'H'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 3.5, 0),
                        new Vector3(7, 3.5, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 4.5, 0),
                        new Vector3(7, 4.5, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 5.5, 0),
                        new Vector3(7, 5.5, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 6.5, 0),
                        new Vector3(7, 6.5, 0)
                    }),

                    // Second 4 vertical lines of 'H'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(7, 0, 0),
                        new Vector3(7, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(8, 0, 0),
                        new Vector3(8, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(9, 0, 0),
                        new Vector3(9, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(10, 0, 0),
                        new Vector3(10, 10, 0)
                    })
                }
            },
            {
                'Y', new List<Curve>
                {
                    // First 4 diagonal lines of 'Y'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(2, 0, 0),
                        new Vector3(7, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 0, 0),
                        new Vector3(8, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4, 0, 0),
                        new Vector3(9, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5, 0, 0),
                        new Vector3(10, 10, 0)
                    }),

                    // Second 4 diagonal lines of 'Y'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4.5, 5, 0),
                        new Vector3(0, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4.857, 5.714, 0),
                        new Vector3(1, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5.214, 6.429, 0),
                        new Vector3(2, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5.571, 7.143, 0),
                        new Vector3(3, 10, 0)
                    })
                }
            },
            {
                'P', new List<Curve>
                {
                    // First 4 vertical lines of 'P'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                        new Vector3(0, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(1, 0, 0),
                        new Vector3(1, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(2, 0, 0),
                        new Vector3(2, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 0, 0),
                        new Vector3(3, 10, 0)
                    }),

                    // Curved line of 'P'
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 10, 0),
                        new Vector3(11, 10.25, 0),
                        new Vector3(9, 6.5, 0),
                        new Vector3(11, 2.75, 0),
                        new Vector3(3, 3, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 9, 0),
                        new Vector3(10, 9.25, 0),
                        new Vector3(8, 6.5, 0),
                        new Vector3(10, 3.75, 0),
                        new Vector3(3, 4, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 8, 0),
                        new Vector3(9, 8.25, 0),
                        new Vector3(7, 6.5, 0),
                        new Vector3(9, 4.75, 0),
                        new Vector3(3, 5, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 7, 0),
                        new Vector3(8, 7.25, 0),
                        new Vector3(6, 6.5, 0),
                        new Vector3(8, 5.75, 0),
                        new Vector3(3, 6, 0)
                    })
                }
            },
            {
                'A', new List<Curve>
                {
                    // First 4 diagonal lines of 'A'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                        new Vector3(3.5, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(1, 0, 0),
                        new Vector3(4.5, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(2, 0, 0),
                        new Vector3(5.5, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 0, 0),
                        new Vector3(6.5, 10, 0)
                    }),

                    // Horizontal line of 'A'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3.7, 2, 0),
                        new Vector3(6.3, 2, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4.05, 3, 0),
                        new Vector3(5.95, 3, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4.4, 4, 0),
                        new Vector3(5.6, 4, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(4.75, 5, 0),
                        new Vector3(5.25, 5, 0)
                    }),

                    // Second 4 diagonal lines of 'A'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5, 5.714, 0),
                        new Vector3(7, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5.5, 7.143, 0),
                        new Vector3(8, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(6, 8.571, 0),
                        new Vector3(9, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(6.5, 10, 0),
                        new Vector3(10, 0, 0)
                    }),
                }
            },
            {
                'R', new List<Curve>
                {
                    // First 4 vertical lines of 'R'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                        new Vector3(0, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(1, 0, 0),
                        new Vector3(1, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(2, 0, 0),
                        new Vector3(2, 10, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(3, 0, 0),
                        new Vector3(3, 10, 0)
                    }),

                    // Curved line of 'R'
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 10, 0),
                        new Vector3(11, 10.25, 0),
                        new Vector3(9, 6.5, 0),
                        new Vector3(11, 2.75, 0),
                        new Vector3(3, 3, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 9, 0),
                        new Vector3(10, 9.25, 0),
                        new Vector3(8, 6.5, 0),
                        new Vector3(10, 3.75, 0),
                        new Vector3(3, 4, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 8, 0),
                        new Vector3(9, 8.25, 0),
                        new Vector3(7, 6.5, 0),
                        new Vector3(9, 4.75, 0),
                        new Vector3(3, 5, 0)
                    }),
                    new Bezier(new List<Vector3>
                    {
                        new Vector3(3, 7, 0),
                        new Vector3(8, 7.25, 0),
                        new Vector3(6, 6.5, 0),
                        new Vector3(8, 5.75, 0),
                        new Vector3(3, 6, 0)
                    }),

                    // First 4 diagonal lines of 'R'
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(5.4523, 3.0955, 0),
                        new Vector3(7, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(6.3667, 3.2666, 0),
                        new Vector3(8, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(7.2245, 3.5510, 0),
                        new Vector3(9, 0, 0)
                    }),
                    new Polyline(new List<Vector3>
                    {
                        new Vector3(8.0041, 3.9918, 0),
                        new Vector3(10, 0, 0)
                    }),
                }
            }
        };
    }
}
