# Examination project: Number 2 - Akima sub-spline
My assignment is to implement the Akima (sub-)spline interpolation. 

AkimaSpline.cs: 
Here's a brief overview of the code:

The class AkimaSpline has private fields x, y, b, c, d, and n, representing the x-values, y-values, and the coefficients used in the Akima spline calculation.
The AkimaSpline class has a private constructor that initializes the fields of the class.
The Create method is a static method of the AkimaSpline class, which creates an instance of the AkimaSpline object. It takes the x-data and y-data arrays as input and calculates the coefficients of the Akima spline.
The Evaluate method calculates the interpolated value of the spline at a given point z.

Using the AkimaSpline:

 In the provided code, the Create method is responsible for creating an instance of the AkimaSpline object. To create this instance, you need to pass in the x-array and y-array of values that you want to use for the Akima spline interpolation.

 Once you have created the AkimaSpline object, you can then use its Evaluate method to calculate interpolated values at specific points, as shown in the code snippet in the previous response.

# ppmnm

| #  | homework      | A | B | C | Σ  |
 ======================================
| 1  | LinEq         | 6 | 3 | 0 | 9  |
---------------------------------------
| 2  | EVD           | 6 | 3 | - |  9 |
---------------------------------------
| 3  | LeastSquares  | 6 | 3 | 1 |  10 |
---------------------------------------
| 4  | Splines       | 6 | - | - |  6 |
---------------------------------------
| 5  | ODE       | 6 | - | - |  6 |
---------------------------------------
| 6  | Integration       | 6 | - | - |  6 |
---------------------------------------
| 7  | Monte Carlo       | 6 | - | - |  6 |
---------------------------------------
| 8  | Root Finding       | 6 | - | - |  0 |
---------------------------------------
| 9 | Minimization      | 0 | - | - |  0 |
---------------------------------------
| 10 | Neural Network     | 0 | - | - |  0 |
---------------------------------------
 ======================================
|                    total points: 58  |
 ======================================

| #  | Exercises      Done/not Done   |
 ======================================
| 1  |          Done
---------------------------------------
| 2  |          Done
---------------------------------------
| 3  |          Done
---------------------------------------
| 4  |          Done
---------------------------------------
| 5  |          Done
---------------------------------------
| 6  |          Done
---------------------------------------
| 7  |          Done
---------------------------------------
| 8  |          Done
---------------------------------------
 ======================================
|                    total Done 8/8   |
 ======================================
