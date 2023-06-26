# Information
Heyy'o this is my repository for the course "praktisk programmering og numeriske metoder" [ppnm](https://kursuskatalog.au.dk/da/course/117654/Praktisk-programmering-og-numeriske-metoder)
I am studying physics at Arhus Universit (2020/2023), I am taking this course in my sixth semester.

# Examination project: Number 2 - [Akima sub-spline](https://github.com/Benedikttk/ppmnm/tree/main/Eksamen)
My assignment is to implement the Akima (sub-)spline interpolation. 
I have used Inspiration from "Yet Another Introduction to Numerical Methods" version June 16, 2023, D.V. Fedorov [The Book](http://212.27.24.106:8080/prog/book/book.pdf), and this has also been part our curriculum.

# Overall Rating
I would self-rate the [exam](https://github.com/Benedikttk/ppmnm/tree/main/Eksamen) to 9/10 points and I have a total of 70/100 points for the [Homework](https://github.com/Benedikttk/ppmnm/tree/main/Assignments) giving a final score of 7.6.

AkimaSpline.cs: 
Here's a brief overview of the code: [AkimaSpline.cs](https://github.com/Benedikttk/ppmnm/blob/main/Eksamen/AkimaSpline.cs)

The class AkimaSpline has private fields x, y, b, c, d, and n, representing the x-values, y-values, and the coefficients used in the Akima spline calculation.
The AkimaSpline class has a private constructor that initializes the fields of the class.
The Create method is a static method of the AkimaSpline class, which creates an instance of the AkimaSpline object. It takes the x-data and y-data arrays as input and calculates the coefficients of the Akima spline.
The Evaluate method calculates the interpolated value of the spline at a given point z.

Using the AkimaSpline: See [main.cs](https://github.com/Benedikttk/ppmnm/blob/main/Eksamen/main.cs).



 In the provided code, the Create method is responsible for creating an instance of the AkimaSpline object. To create this instance, you must pass in the x-array and y-array of values you want to use for the Akima spline interpolation.

 Once you have created the AkimaSpline object, you can use its Evaluate method to calculate interpolated values at specific points.

# ppnm

| #  | [homework](https://github.com/Benedikttk/ppmnm/tree/main/Assignments)      | A | B | C | Σ  |
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

| #  | [Exercises](https://github.com/Benedikttk/ppmnm/tree/main/T%C3%B8)      Done/not Done   |
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
