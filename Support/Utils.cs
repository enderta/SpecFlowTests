using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowProject.Support
{
    public class Utils
    {
        public static void PerformSwipe(WebDriver _driver, Point start, Point end)
        {
            var finger = new PointerInputDevice(PointerKind.Touch);
            var swipe = new ActionSequence(finger);
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromMilliseconds(1000)));
            swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));
            _driver.PerformActions(new List<ActionSequence> { swipe });
        }
    }
}