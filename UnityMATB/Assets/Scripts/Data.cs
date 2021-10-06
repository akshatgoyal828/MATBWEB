using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class Data : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void addToDatabase(string jsonString);
    [DllImport("__Internal")]
    private static extern void initFirebase();

    //public static string[] dataArray;
    public static List<string> dataArray = new List<string>();
    string path;

    public static float f1Ratio = 0f;
    public static float f2Ratio = 0f;
    public static float f3Ratio = 0f;
    public static float f4Ratio = 0f;
    public static float f5Ratio = 0f;
    public static float f6Ratio = 0f;

    public static double RMSD_A = 0d;
    public static double RMSD_B = 0d;

    public static double RMSD_tracking = 0d;

    public static float comRatio = 0f;

    //index for the file writing array
    public static int i = 0;

    void Start()
    {
        initFirebase();
        //writing to the notepad file
        //path = Application.dataPath + "/data.txt";
        //dataArray = new string[1000];
        WriteFunction();
    }

    void WriteFunction()
    {
        //Invoke this same function after 8 minutes
        Invoke("WriteFunction", 8);
        //if (ElapsedTime.minutes >= 9)
        {
            //f1Ratio = F1.correct / F1.no;
            //f2Ratio = F2.correct / F2.no;
            //f3Ratio = F3.correct / F3.no;
            //f4Ratio = F4.correct / F4.no;
            //f5Ratio = F5.correct / F5.no;
            //f6Ratio = F6.correct / F6.no;

            //RMSD_A = Math.Sqrt(tankA.sum / tankA.no);
            //RMSD_B = Math.Sqrt(tankB.sum / tankB.no);

            //RMSD_tracking = Math.Sqrt(Joystick.sum / Joystick.no);

            //comRatio = Enter.correct / Enter.no;

            //Writing the data for task System Monitoring
            //dataArray[i++] = "System Monitoring:";
            //dataArray[i++] = "F1 proportion of correct responses = " + f1Ratio;
            //dataArray[i++] = "F1 Total Reaction Time = " + F1.sumTime + "secs";
            //dataArray[i++] = "F2 proportion of correct responses = " + f2Ratio;
            //dataArray[i++] = "F2 Total Reaction Time = " + F2.sumTime + "secs";
            //dataArray[i++] = "F3 proportion of correct responses = " + f3Ratio;
            //dataArray[i++] = "F3 Total Reaction Time = " + F3.sumTime + "secs";
            //dataArray[i++] = "F4 proportion of correct responses = " + f4Ratio;
            //dataArray[i++] = "F4 Total Reaction Time = " + F4.sumTime + "secs";
            //dataArray[i++] = "F5 proportion of correct responses = " + f5Ratio;
            //dataArray[i++] = "F5 Total Reaction Time = " + F5.sumTime + "secs";
            //dataArray[i++] = "F6 proportion of correct responses = " + f6Ratio;
            //dataArray[i++] = "F6 Total Reaction Time = " + F6.sumTime + "secs";
            //dataArray[i++] = "--------------------------------------------------";
            //dataArray[i++] = "                                        ";

            //Writing data for the resource management task
            //dataArray[i++] = "Resource Management:";
            //dataArray[i++] = "RMSD of TankA:" + RMSD_A;
            //dataArray[i++] = "RMSD of TankB:" + RMSD_B;
            //dataArray[i++] = "--------------------------------------------------";
            //dataArray[i++] = "                                        ";

            //Writing the data for the task Tracking
            //dataArray[i++] = "Tracking Task:";
            //dataArray[i++] = "RMSD of Tracking:" + RMSD_tracking;
            //dataArray[i++] = "--------------------------------------------------";
            //dataArray[i++] = "                                        ";

            //Writing data for the communications task
            //dataArray[i++] = "Communications Task:";
            //dataArray[i++] = "Proportion of correct responses:" + comRatio;

            //File.WriteAllLines(path, dataArray); 

            //Call this piece of code to push data in firestore;
            FinalObservations observations = new FinalObservations();
            observations.F1_0 = f1Ratio;
            observations.F1_1 = F1.sumTime;
            observations.F2_0 = f2Ratio;
            observations.F2_1 = F2.sumTime;
            observations.F3_0 = f3Ratio;
            observations.F3_1 = F3.sumTime;
            observations.F4_0 = f4Ratio;
            observations.F4_1 = F4.sumTime;
            observations.F5_0 = f5Ratio;
            observations.F5_1 = F5.sumTime;
            observations.F6_0 = f6Ratio;
            observations.F6_1 = F6.sumTime;
            observations.RMSD_A = RMSD_A;
            observations.RMSD_B = RMSD_B;
            observations.RMSD_tracking = RMSD_tracking;
            observations.comRatio = comRatio;

            string json = JsonUtility.ToJson(observations);
            addToDatabaseOnce(json);
        }
    }

    void addToDatabaseOnce(string jsonString) {
         addToDatabase(jsonString);
    }
}

[Serializable]
public class FinalObservations
{
    public float F1_0 = 0;
    public float F1_1 = 0;
    public float F2_0 = 0;
    public float F2_1 = 0;
    public float F3_0 = 0;
    public float F3_1 = 0;
    public float F4_0 = 0;
    public float F4_1 = 0;
    public float F5_0 = 0;
    public float F5_1 = 0;
    public float F6_0 = 0;
    public float F6_1 = 0;
    public double RMSD_A = 0;
    public double RMSD_B = 0;
    public double RMSD_tracking = 0;
    public float comRatio = 0;
}