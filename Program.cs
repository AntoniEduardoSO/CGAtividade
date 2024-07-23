public class Program
{
    public class Bresenham
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int D { get; set; }
        public string Pixel { get; set; } = string.Empty;

        public int Inc { get; set; }
    }

    public static void Main()
    {
        List<Bresenham> steps = [];
        int x1 = 1, y1 = 1, x2 = 8, y2 = 5;
        steps = Inc_line(x1, y1, x2, y2);

        foreach (var step in steps)
        {
            Console.WriteLine($"X: {step.X}, Y: {step.Y}, D: {step.D}, Pixel: {step.Pixel}, Inc: {step.Inc}");
        }
    }

    public static List<Bresenham> Inc_line(int x1, int y1, int x2, int y2)
    {
        List<Bresenham> steps = [];
        int dx, dy, incE, incNE, d, x, y;

        dx = x2 - x1;
        dy = y2 - y1;
        d = (2 * dy) - dx;
        incE = 2 * dy;
        incNE = 2 * (dy - dx);
        x = x1;
        y = y1;

        steps.Add(new Bresenham
        {
            X = x,
            Y = y,
            D = d,
            Pixel = d > 0 ? "NE" : "E",
            Inc = d > 0 ? d + incNE : d + incE
        });

        while (x < x2)
        {
            if (d <= 0)
            {
                d += incE;
                x++;
            }

            else
            {
                d += incNE;
                x++;
                y++;
            }

            steps.Add(new Bresenham
            {
                X = x,
                Y = y,
                D = d,
                Pixel = d > 0 ? "NE" : "E",
                Inc = d > 0 ? d + incNE : d + incE
            });
        }

        return steps;
    }

}

