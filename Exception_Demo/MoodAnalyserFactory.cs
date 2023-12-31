﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Demo
{
    public class MoodAnalyserFactory
    {
        

        public static Object CreateMoodAnalyserObject(string className, string constructor)
        {
            try
            {
                string classname = "Exception_Demo.MoodAnalyser";
                string constructorname = "MoodAnalyser";
              
                if (classname != className)
                {
                    throw new MoodAnalys_Exception(MoodAnalys_Exception.ExceptionType.NO_SUCH_CLASS, "no class found");
                }
                if (constructorname != constructor)
                {
                    throw new MoodAnalys_Exception(MoodAnalys_Exception.ExceptionType.NO_FOUND_CONSTRUCTOR, "No such Constructor");
                }

                if (classname != className)
                {
                    throw new MoodAnalys_Exception(MoodAnalys_Exception.ExceptionType.NO_SUCH_CLASS, "no class found");
                }
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalyserType = assembly.GetType(className);
                return Activator.CreateInstance(moodAnalyserType);
            }
            catch (MoodAnalys_Exception e)
            {
                return e.Message;
            }

           
        }
        public static Object CreateMoodAnalyserObjectWithParameterizedConstructor(string className, string constructor)
        {
            try
            {
                string classname = "Exception_Demo.MoodAnalyser";
                string constructorname = "MoodAnalyser(message)";
                if (classname != className)
                {
                    throw new MoodAnalys_Exception(MoodAnalys_Exception.ExceptionType.NO_SUCH_CLASS, "no class found");
                }

                if (constructorname != constructor)
                {
                    throw new MoodAnalys_Exception(MoodAnalys_Exception.ExceptionType.NO_FOUND_CONSTRUCTOR, "No such Constructor");
                }

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalyserType = assembly.GetType(className);
               return Activator.CreateInstance(moodAnalyserType);
               


            }
            catch (MoodAnalys_Exception e)
            {
                return e.Message;
            }
        }
        public static string InvokeMethodWithReflection(string className, string message)
        {
            try
            {
             
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalyserType = assembly.GetType(className);
                Object CreatedObject = Activator.CreateInstance(moodAnalyserType,message);
                Type type = CreatedObject.GetType();
                MethodInfo methodinfo = type.GetMethod("analyseMood");
                string result = (string)methodinfo.Invoke(CreatedObject, null);
                return result;

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



    }
}
