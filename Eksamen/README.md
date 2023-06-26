# Examination project: Number 2 - Akima sub-spline
My assignment is to implement the Akima (sub-)spline interpolation. 
I have used Inspiration from "Yet Another Introduction to Numerical Methods" version June 16, 2023, D.V. Fedorov [The Book](http://212.27.24.106:8080/prog/book/book.pdf) and has also been our curriculum.

AkimaSpline.cs: 
Here's a brief overview of the code: [AkimaSpline.cs](https://github.com/Benedikttk/ppmnm/blob/main/Eksamen/AkimaSpline.cs)

The class AkimaSpline has private fields x, y, b, c, d, and n, representing the x-values, y-values, and the coefficients used in the Akima spline calculation.
The AkimaSpline class has a private constructor that initializes the fields of the class.
The Create method is a static method of the AkimaSpline class, which creates an instance of the AkimaSpline object. It takes the x-data and y-data arrays as input and calculates the coefficients of the Akima spline.
The Evaluate method calculates the interpolated value of the spline at a given point z.

Using the AkimaSpline: See [main.cs](https://github.com/Benedikttk/ppmnm/blob/main/Eksamen/main.cs).



 In the provided code, the Create method is responsible for creating an instance of the AkimaSpline object. To create this instance, you need to pass in the x-array and y-array of values that you want to use for the Akima spline interpolation.

 Once you have created the AkimaSpline object, you can then use its Evaluate method to calculate interpolated values at specific points.
