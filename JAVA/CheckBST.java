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
        if (root.left != null && root.right != null && root.left.data == root.right.data ) { return false; }

        boolean leftValid = true;
        boolean rightValid = true;

        if (root.left != null) {
            Node leftNode = root.left;
            while (leftNode != null) {
                if (leftNode.data >= root.data) { return false; }
                if (leftNode.right != null && leftNode.right.data >= root.data) { return false; }
                leftNode = leftNode.left;
            }
            leftValid = checkBST(root.left);
        }
        
        if (root.right != null) {
            Node rightNode = root.right;
            while (rightNode != null) {
                if (rightNode.data <= root.data) { return false; }
                if (rightNode.left != null && rightNode.left.data <= root.data) { return false; }
                rightNode = rightNode.left;
            }
            rightValid = checkBST(root.right);
        }
        
        if (leftValid == false) { return false; }
        if (rightValid == false) { return false;}

        return true;
    }
}

class Node {
    int data;
    Node left;
    Node right;

    public Node(int data) { this.data = data; }
}