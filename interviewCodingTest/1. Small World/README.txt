//To use this application with various input values, change the input values directly in the DataManipulation.js and run the application in Node.JS.

// Input Values
var categories = "CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N";
var expenses = "Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS";

/** 

WorldThatIsNotVeryBig:
Input: Accepts a file of points in the format "ID Lat Lon", where each point is a single line of the file. 
Result: Displays the closest three points to each point on the console.
Usage: WorldThatIsNotVeryBig [options]"
Options: 
  (--file|-f) file_path_name        Load the input data from file.
  (--help|-h)                       Display Help.
  
**/
/**
 * Small World
 *   Given a list of points in the plane, write a program that outputs each point along with the three other points that are closest to it.
 *   These three points should be ordered by distance.
 *
 * For example, given a set of points where each line is of the form: ID x-coordinate y-coordinate
 *
 * 1  0.0      0.0
 * 2  10.1     -10.1
 * 3  -12.2    12.2
 * 4  38.3     38.3
 * 5  79.99    179.99
 *
 *
 * Your program should output:
 *
 * 1 2,3,4
 * 2 1,3,4
 * 3 1,2,4
 * 4 1,2,3
 * 5 4,3,1 
 **/
 

