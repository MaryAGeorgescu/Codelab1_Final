
using System.Collections;
using System.Collections.Generic;

public class StoryNode //class that hold data for this location in the simple Zork Game
{
    public int locationNum;
    public string storyText;
    public int wLocation;
    public int eLocation;
    public int nLocation;
    public int sLocation;

    public StoryNode() //default constructor
    {
        locationNum = 0;
        storyText = "This is default question text.";
    }

    public StoryNode(int pageNumber, string storyText)
    {
        this.locationNum = pageNumber;
        this.storyText = storyText;
    }

    public StoryNode(int pageNumber, string storyText, string option1Text, string option2Text)
    {
        this.locationNum = pageNumber;
        this.storyText = storyText;
    }
}
