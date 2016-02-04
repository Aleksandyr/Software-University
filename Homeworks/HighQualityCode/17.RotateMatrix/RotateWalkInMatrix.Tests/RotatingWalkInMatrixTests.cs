using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RotatingWalkInMatrixTests
{

    [TestMethod]
    public void TestWalkingMatrixWithValueOfOne()
    {
        int matrixLength = 1;

        int[,] expectedMatrix =
        {
            { 1 }
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfTwo()
    {
        int matrixLength = 2;

        int[,] expectedMatrix =
        {
            { 1, 4 },
            { 3, 2 }
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfThree()
    {
        int matrixLength = 3;

        int[,] expectedMatrix =
        {
            { 1, 7, 8 },
            { 6, 2, 9 },
            { 5, 4, 3 }
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfFour()
    {
        int matrixLength = 4;

        int[,] expectedMatrix =
        {
            { 1, 10, 11, 12 },
            { 9, 2, 15, 13 },
            { 8, 16, 3, 14 },
            { 7, 6, 5, 4 },
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfFive()
    {
        int matrixLength = 5;

        int[,] expectedMatrix =
        {
            { 1, 13, 14, 15, 16 },
            { 12, 2, 21, 22, 17 },
            { 11, 23, 3, 20, 18 },
            { 10, 25, 24, 4, 19 },
            { 9, 8, 7, 6, 5 }
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfSix()
    {
        int matrixLength = 6;

        int[,] expectedMatrix =
        {
            { 1, 16, 17, 18, 19, 20 },
            { 15, 2, 27, 28, 29, 21 },
            { 14, 31, 3, 26, 30, 22 },
            { 13, 36, 32, 4, 25, 23 },
            { 12, 35, 34, 33, 5, 24 },
            { 11, 10, 9, 8, 7, 6 },
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }

    [TestMethod]
    public void TestWalkingMatrixWithValueOfFifteen()
    {
        int matrixLength = 15;

        int[,] expectedMatrix =
        {
            { 1, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 },
            { 42, 2, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 57 },
            { 41, 148, 3, 80, 111, 112, 113, 114, 115, 116, 117, 118, 119, 93, 58 },
            { 40, 180, 149, 4, 79, 110, 132, 133, 134, 135, 136, 137, 120, 94, 59 },
            { 39, 179, 181, 150, 5, 78, 109, 131, 144, 145, 146, 138, 121, 95, 60 },
            { 38, 178, 204, 182, 151, 6, 77, 108, 130, 143, 147, 139, 122, 96, 61 },
            { 37, 177, 203, 205, 183, 152, 7, 76, 107, 129, 142, 140, 123, 97, 62 },
            { 36, 176, 202, 219, 206, 184, 153, 8, 75, 106, 128, 141, 124, 98, 63 },
            { 35, 175, 201, 218, 220, 207, 185, 154, 9, 74, 105, 127, 125, 99, 64 },
            { 34, 174, 200, 217, 225, 221, 208, 186, 155, 10, 73, 104, 126, 100, 65 },
            { 33, 173, 199, 216, 224, 223, 222, 209, 187, 156, 11, 72, 103, 101, 66 },
            { 32, 172, 198, 215, 214, 213, 212, 211, 210, 188, 157, 12, 71, 102, 67 },
            { 31, 171, 197, 196, 195, 194, 193, 192, 191, 190, 189, 158, 13, 70, 68 },
            { 30, 170, 169, 168, 167, 166, 165, 164, 163, 162, 161, 160, 159, 14, 69 },
            { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15 }
        };
        int[,] currentMatrix = RotatingWalkInMatrix.GenerateWalkingMatrix(matrixLength);

        CollectionAssert.AreEqual(expectedMatrix, currentMatrix, "Two matrixes are not equal");
    }
}