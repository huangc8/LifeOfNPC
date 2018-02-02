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
		public int id; // id of the node
		public int dialogType; // dialog type 0 - conv, 1 - buy, 2 - sell
		public int who;	// who is talking 0 - shopkeeper, 1 - hero
		public int stop; // end dialog 0 - continue, 1 - stop
		public int success; // success node numb
		public int fail; // fail node numb

        //line of dialog the will be put in dialog box
        public string line;
    }

	public static void CreateTree(StreamReader file, List<DialogTreeNode> HeroDialogTree, int BuyNode, int SellNode)
    {
        
        string ReadLine = file.ReadLine();//reads in first line of text file
		DialogTreeNode lastNode = null;
		int currentNode = 0;
		while (ReadLine != null)
        {
            
			DialogTreeNode node = new DialogTreeNode();

			// id
			node.id = currentNode;

			// dialog type
			node.dialogType = int.Parse(ReadLine.Substring(0, 1)); //get the conversation type
			if (lastNode != null && node.dialogType != lastNode.dialogType) {
				if (node.dialogType == 1) {
					BuyNode = currentNode;
				} else if (node.dialogType == 2) {
					SellNode = currentNode;
				} else {
					Debug.Log ("Error: no such dialogType");
				}
			}

			// who
			node.who = int.Parse(ReadLine.Substring(1,2));

			// stop
			node.stop = int.Parse(ReadLine.Substring(2,3));

			if (node.dialogType != 0 && node.stop == 1) {
				node.success = int.Parse (ReadLine.Substring (3	,5));
				node.fail = int.Parse (ReadLine.Substring (5,7));
			}
            
            node.line = ReadLine.Substring(12);//sets nodes line of dialog
            HeroDialogTree.Add(node);//adds node to dialog "tree"

            ReadLine = file.ReadLine();//reads in next line of text file
			lastNode = node;
			currentNode++;
        }

    }

    public static int Traverse(DialogTreeNode Node, bool success)
    {
		if(Node.stop == 1)//if node has more than 1 branch
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
			return Node.stop;
        }

    }

}
