using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;

class Program
{
    static void Main()
    {
        var model = new PlotModel { Title = "Percentage of Total Time Worked by Indian Employees" };
        var pieSeries = new PieSeries
        {
            StrokeThickness = 1.0,
            InsideLabelPosition = 0.8,
            AngleSpan = 360,
            StartAngle = 0,
            InsideLabelFormat = "{1}: {2:0.0}%"  // {1} - label, {2} - value
        };

        // Employee names and hours
        var employees = new List<(string Name, double Hours)>
        {
            ("Aarav", 38), ("Ananya", 42), ("Rohan", 35), ("Isha", 40), ("Raj", 37),
            ("Sneha", 41), ("Karan", 39), ("Divya", 36), ("Vikram", 44), ("Pooja", 43),
            ("Rahul", 34), ("Neha", 40), ("Sanjay", 38), ("Meera", 37), ("Arjun", 39),
            ("Priya", 41), ("Manish", 36), ("Lakshmi", 43), ("Dinesh", 42), ("Anjali", 35)
        };

        foreach (var emp in employees)
        {
            pieSeries.Slices.Add(new PieSlice(emp.Name, emp.Hours));
        }

        model.Series.Add(pieSeries);

        var pngExporter = new PngExporter { Width = 800, Height = 600 };
        using (var stream = File.Create("EmployeePieChart.png"))
        {
            pngExporter.Export(model, stream);
        }

        Console.WriteLine("Pie chart saved as EmployeePieChart.png");
    }
}
