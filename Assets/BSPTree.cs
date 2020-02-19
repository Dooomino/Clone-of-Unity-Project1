using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BSPTree : MonoBehaviour
{
    [SerializeField] private int depth =3;
    [SerializeField] private int size = 10;
    private float margin = 0.30f;
    private Tilemap tilemap;
    private Node root;
    void start(){
        tilemap = GetComponent<Tilemap>();
        root = new Node(new Vector2(0, 0), new Vector2(size, size));
    }
    [ContextMenu("Clear Tree")]
    public void clearTree(){
        clearTree(root);
    }
    [ContextMenu("Generate")]
    public void Generate(){
        root = new Node(new Vector2(0, 0), new Vector2(size, size));
        genNode(root, 0);
        drawTree(root, 0);
    }
    //Recursively destroy the tree. 
    private void clearTree(Node node){
        if(node == null){
            return;
        }
        clearTree(node.leftNode);
        clearTree(node.rightNode);
        node = null;
    }
    private void drawTree(Node parentNode, int currentDepth){
        if(parentNode == null){
            return;
        }
        //This should draw a rectangle of the split regions
        Debug.DrawLine((Vector3)parentNode.getLeftBot(), (Vector3)(parentNode.getLeftBot() + new Vector2(0, parentNode.height()))); //Left side
        Debug.DrawLine((Vector3)parentNode.getLeftBot(), (Vector3)(parentNode.getLeftBot() + new Vector2(0, parentNode.width()))); //bot side
        Debug.DrawLine((Vector3)parentNode.getRightTop(), (Vector3)(parentNode.getRightTop() + new Vector2(0, parentNode.width()))); //top side
        Debug.DrawLine((Vector3)parentNode.getRightTop(), (Vector3)(parentNode.getRightTop() + new Vector2(0, parentNode.height()))); //Right Side
        Debug.Log(currentDepth);
        drawTree(parentNode.leftNode, currentDepth + 1);
        drawTree(parentNode.rightNode,currentDepth + 1);

    }
    private void genNode(Node parentNode, int currentDepth){
        if(currentDepth == depth){
            return;
        }
        //We want to alternate between spliting horizontally and vertically to prevent narrow and long rectangles
        if(parentNode.width() > parentNode.height()){
            float splitMargin = parentNode.width() * this.margin;
            float splitWidth = Random.Range(parentNode.width() - splitMargin, parentNode.width() + splitMargin); //Find a random width to split the rectangle on
            
            Vector2[] corners = createRectangle(parentNode.getLeftBot().x, parentNode.getLeftBot().y, splitWidth, parentNode.height());
            parentNode.leftNode = new Node(corners[0], corners[1]);

            corners = createRectangle(corners[0].x + splitWidth, parentNode.getLeftBot().y, parentNode.width() - splitWidth, parentNode.height());
            parentNode.rightNode = new Node(corners[0], corners[1]);
        }else{
            
            float splitMargin = parentNode.height() * this.margin;
            float splitHeight = Random.Range(parentNode.height() - splitMargin, parentNode.height() + splitMargin); //Same as above

            Vector2[] corners = createRectangle(parentNode.getLeftBot().x, parentNode.getLeftBot().y, parentNode.width(), splitHeight);
            parentNode.leftNode = new Node(corners[0], corners[1]);

            corners = createRectangle(corners[0].x, corners[0].y + splitHeight, parentNode.width(), parentNode.height() - splitHeight);
            parentNode.rightNode = new Node(corners[0], corners[1]);
        }

        genNode(parentNode.leftNode, currentDepth + 1);
        genNode(parentNode.rightNode, currentDepth + 1);
    }
    //Returns the bottom left and upper right of a rectangle bounding box
    private Vector2[] createRectangle(float x, float y, float width, float height){
        Vector2[] result = new Vector2[2];
        Vector2 botLeft;
        botLeft.x = x;
        botLeft.y = y;

        Vector2 topRight;
        topRight.x = botLeft.x + width;
        topRight.y = botLeft.y + height;
        result[0] = botLeft;
        result[1] = topRight;
        return result;
    }
    
}
