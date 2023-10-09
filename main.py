import math
import numpy as np

def Solve(A, b, eps, max_iterations = 100):
    n = len(b)
    d = [b[i] / A[i][i] for i in range(n)]
    C = A
    

    for i in range(n):
        temp = C[i][i]
        for j in range(n):
            C[i][j] = (C[i][j] / temp) * -1
        C[i][i] = 0
    print(C)
    print(d)

    x = d.copy()
    x_prev = d.copy()
    
    for k in range(max_iterations):
        max_error = 0     
        for i in range(n):
            temp = 0
            for j in range(n):
                temp += C[i][j] * x_prev[j]
            x[i] = round((d[i] + temp), 4)
            error = abs(x[i] - x_prev[i])
            max_error = max(max_error, error)
        x_prev = x.copy()
        print(max_error)
        if max_error < eps: 
            return x
        print(f"Ітерація ({k+1}): {x}")
    print("СЛАР не збігся")
    return

if __name__ == "__main__":
    A = [
        [4,2,2],
        [2,3,2],
        [-1,1,1]
    ]

    b = [8,7,1]

    
    eps = 0.001
    print(Solve(A, b, eps))
