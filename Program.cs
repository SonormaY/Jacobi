double[] Solve(double[][] A, double[] b, double tolerance = 1e-6, int maxIterations = 1000)
{
    int n = b.Length;
    double[] x = new double[n];
    double[] xNew = new double[n];

    for (int iteration = 0; iteration < maxIterations; iteration++)
    {
        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < n; j++)
            {
                if (j != i)
                {
                    sum += A[i][j] * x[j];
                }
            }
            xNew[i] = (b[i] - sum) / A[i][i];
        }

        // Перевірка на збіжність за допомогою відносної різниці між двома послідовними наближеннями.
        double maxDifference = 0;
        for (int i = 0; i < n; i++)
        {
            double difference = Math.Abs(xNew[i] - x[i]);
            if (difference > maxDifference)
            {
                maxDifference = difference;
            }
        }

        if (maxDifference < tolerance)
        {
            return xNew; // Збіжність досягнута.
        }

        Array.Copy(xNew, x, n);
    }

    throw new Exception("Метод Якобі не збігся протягом вказаної кількості ітерацій.");
}

Console.WriteLine(1);