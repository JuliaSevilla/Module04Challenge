#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace Module04Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // 1. Create ribbon tab

            try
            {
                app.CreateRibbonTab("Revit Add-in Bootcamp");
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // 2. Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, "Revit Add-in Bootcamp", "Revit Tools");

            // 3. Create button data instances
            ButtonDataClass myButtonData1 = new ButtonDataClass("btn1", "Button 1", Command1.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 1");
            ButtonDataClass myButtonData2 = new ButtonDataClass("btn2", "Button 2", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 2");
            ButtonDataClass myButtonData3 = new ButtonDataClass("btn3", "Button 3", Command2.GetMethod(), Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 3");
            ButtonDataClass myButtonData4 = new ButtonDataClass("btn4", "Button 4", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 4");
            ButtonDataClass myButtonData5 = new ButtonDataClass("btn5", "Button 5", Command2.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 5");
            ButtonDataClass myButtonData6 = new ButtonDataClass("btn6", "Button 6", Command2.GetMethod(), Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 6");
            ButtonDataClass myButtonData7 = new ButtonDataClass("btn7", "Button 7", Command2.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 7");
            ButtonDataClass myButtonData8 = new ButtonDataClass("btn8", "Button 8", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 8");
            ButtonDataClass myButtonData9 = new ButtonDataClass("btn9", "Button 9", Command2.GetMethod(), Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 8");
            ButtonDataClass myButtonData10 = new ButtonDataClass("btn10", "Button 10", Command2.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 8");

            // 4. Create two push buttons
            PushButton myButton1 = panel.AddItem(myButtonData1.Data) as PushButton;
            PushButton myButton2 = panel.AddItem(myButtonData2.Data) as PushButton;

            //5. Create stacked button
            panel.AddStackedItems(myButtonData3.Data, myButtonData4.Data,myButtonData5.Data);

            //6. Create split button 
            SplitButtonData splitButtonData = new SplitButtonData("split", "Split\rButton");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(myButtonData6.Data);
            splitButton.AddPushButton(myButtonData7.Data);

            // 7. Create pull down button
            PulldownButtonData pullDownData = new PulldownButtonData("pulldown1", "More Tools");
            pullDownData.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_32);
            pullDownData.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_16);


            PulldownButton pullDownButton = panel.AddItem(pullDownData) as PulldownButton;
            pullDownButton.AddPushButton(myButtonData8.Data);
            pullDownButton.AddPushButton(myButtonData9.Data);
            pullDownButton.AddPushButton(myButtonData10.Data);

            // NOTE:
            // To create a new tool, copy lines 35 and 39 and rename the variables to "btnData3" and "myButton3". 
            // Change the name of the tool in the arguments of line 

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


    }
}
