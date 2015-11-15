using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogTree : MonoBehaviour
{
    public class DialogTreeNode
    {
        public int next;
        public int success;
        public int fail;

        //line of dialog the will be put in dialog box
        public string line;
    }

    public static void CreateTree(FileInfo file, List<DialogTreeNode> HeroDialogTree)
    {
        StreamReader reader = file.OpenText();//opens text file
        string ReadLine = reader.ReadLine();//reads in first line of text file

        while (ReadLine != null)
        {
            DialogTreeNode node = new DialogTreeNode();
            int numbranches = int.Parse(ReadLine.Substring(0, 1));//gets number of branches
            if (numbranches > 1)//if more than 1 branch
            {
                node.fail = int.Parse(ReadLine.Substring(1, 2)) - 1;//gets number of next node
                node.success = int.Parse(ReadLine.Substring(3, 2)) - 1;//gets number of next node
            }
            else
            {
                node.next = int.Parse(ReadLine.Substring(1, 2)) - 1;
            }

            node.line = ReadLine.Substring(12);//sets nodes line of dialog

            HeroDialogTree.Add(node);//adds node to dialog "tree"

            ReadLine = reader.ReadLine();//reads in next line of text file
        }

    }

    public static int Traverse(DialogTreeNode Node, bool success)
    {
        if(Node.next == 0)//if node has more than 1 branch
        {
            if (success)//if transaction was successful
            {
                return Node.success;
            }
            else//if transaction failed
            {
                return Node.fail;
            }
        }
        else
        {
            return Node.next;
        }

    }

}
