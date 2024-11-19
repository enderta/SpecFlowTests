using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpecFlowProject
{
    public class Utils2
    {
        public static void Swipe(AndroidDriver driver, Point start, Point end)
        {
            // Create a PointerInputDevice for touch input
            var finger = new PointerInputDevice(OpenQA.Selenium.Interactions.PointerKind.Touch);
            var swipe = new ActionSequence(finger);

        // Add actions to the swipe sequence
        swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
        swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
        swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromMilliseconds(1000)));
        swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));

        // Perform the swipe action
        driver.PerformActions(new List<ActionSequence> { swipe });
    }
     public static void TapElement(AndroidDriver driver, IWebElement element)
        {
            // Create a PointerInputDevice for touch input
            var finger = new PointerInputDevice(OpenQA.Selenium.Interactions.PointerKind.Touch);
            var tap = new ActionSequence(finger);
            // Get the location of the element to tap
            var rect = element.Location;

            // Add actions to the tap sequence
            tap.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, rect.X, rect.Y, TimeSpan.Zero));
            tap.AddAction(finger.CreatePointerDown(MouseButton.Left));
            tap.AddAction(finger.CreatePointerUp(MouseButton.Left));

            // Perform the tap action
            driver.PerformActions(new List<ActionSequence> { tap });

            // Wait for 2 seconds
            Thread.Sleep(2000);
        }
    }
}