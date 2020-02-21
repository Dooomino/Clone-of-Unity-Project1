using UnityEngine;
class Node{
    public Node leftNode;
    public Node rightNode;
    private Vector2 leftBot;
    private Vector2 rightTop;

    


    public Node(Vector2 leftBot, Vector2 rightTop){
        this.leftBot = leftBot;
        this.rightTop = rightTop;
        leftNode = null;
        rightNode = null;
    }

    public float width(){
        return Mathf.Abs(leftBot.x - rightTop.x);
    }
    public float height(){
        return Mathf.Abs(leftBot.y - rightTop.y);
    }

    public Vector2 getLeftBot()
    {
        return this.leftBot;
    }

    public Vector2 getRightTop()
    {
        return this.rightTop;
    }
    ~Node(){
        
    }
}