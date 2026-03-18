using System;

class Node
{
    public int id;
    public string name;
    public Node next;

    public Node(int i, string n)
    {
        id = i;
        name = n;
        next = null;
    }
}

class LinkedList
{
    Node head = null;

  
    public void InsertBeg(int id, string name)
    {
        Node n = new Node(id, name);
        n.next = head;
        head = n;
    }


    public void InsertEnd(int id, string name)
    {
        Node n = new Node(id, name);

        if (head == null)
        {
            head = n;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = n;
    }


    public void Delete(int id)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        
        if (head.id == id)
        {
            head = head.next;
            return;
        }

        Node temp = head;

        while (temp.next != null && temp.next.id != id)
        {
            temp = temp.next;
        }

        if (temp.next == null)
        {
            Console.WriteLine("Employee not found");
        }
        else
        {
            temp.next = temp.next.next;
        }
    }

  
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.id + " - " + temp.name);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        
        list.InsertEnd(101, "John");
        list.InsertEnd(102, "Sara");
        list.InsertEnd(103, "Mike");

   
        list.Delete(102);

        Console.WriteLine("Employee List After Deletion:");
        list.Display();
    }
}