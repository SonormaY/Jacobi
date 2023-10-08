using System.Numerics;

Vector<double> Solve(double[,] A, double[] b, double eps)
{
    int n = b.Length;
    Vector<double> x = new Vector<double>(n);
    Vector<double> x_prev = new Vector<double>(n);

    while (Norm(x - x_prev) > eps)
    {
        x_prev = x;
        for (int i = 0; i < n; i++)
        {
            double temp = 0;
            for (int j = 0; j < n; j++) if (i != j) temp += A[i, j] * x_prev[j];
            temp = (b[i] - temp) / A[i, i];
        }
    }


    return x;
}

double Norm(Vector<double> x)
{
    return Math.Sqrt(Vector.Sum(x * x));
}


