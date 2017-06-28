// Author: http://lemming.life
// Language: JAVA
// Purpose: Checks if the tree is a Binary Search Tree
// Defined as: a left node's data must be less than its data and right node's data must be greater than its data.

// Build: javac CheckBST.java
// Run: java CheckBST

class CheckBST {
    public static void main(String args[]) {
        Node root = new Node(4);
        root.left = new Node(2);    root.left.left = new Node(1);   root.left.right = new Node(3);
        root.right = new Node(6);   root.right.left = new Node(5);  root.right.right = new Node(7);

        System.out.println("Is 1st BST: " + ( checkBST(root) ? "yes" : "no") + " ,expected: yes");

        root = new Node(4);
        root.left = new Node(5);
        root.right = new Node(6);

        System.out.println("Is 2nd BST: " + ( checkBST(root) ? "yes" : "no") + " ,expected: no");

    }

    public static boolean checkBST(Node root) {
        if (root.left == null && root.right == null) { return true; };
        
        boolean leftResult = false;
        boolean rightResult = false;
        
        if (root.left != null) {
            if (root.left.data >= root.data) { return false; }
            leftResult = checkBST(root.left);
        }
        
        if (root.right != null) {
            if (root.right.data <= root.data) { return false; }
            rightResult = checkBST(root.right);
        }
        
        if (leftResult == false || rightResult == false) { return false; }
        return true;
    }
}

class Node {
    int data;
    Node left;
    Node right;

    public Node(int data) { this.data = data; }
}