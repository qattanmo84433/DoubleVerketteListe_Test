using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVerketteListe_Test
{
    public class MyList : IEnumerable
    { 
    public class Wrapper
    {
        public Student stu;
        public string Name { get { return stu.name; } }
        public Wrapper next; //vorheriges Element
        public Wrapper prev; //Nächstes Element
                             //Jedes Object hat immer zwei Zeiger   ..... irgendwas => <=Isra =>  <= irgendwas => ...
        public Wrapper(Student stu)
        {
            this.stu = stu;
        }
    }
    Wrapper head;
    Wrapper tail;
    //Add AmAnfang
    public void AddFirst(string name)
    {
        Wrapper newElement = new Wrapper(new Student(name)); //das  hinzuzufügende Element
        if (head == null) //Wenn die Liste Leer
            head = tail = newElement;
        else
        { //else
            newElement.next = head; //newElement => head; .... new Element zeigt auf head(das erste Element in der Liste)
            head.prev = newElement;      //newElement => <= head; //head.prev zeigt auf NewElement statt null
            head = newElement;          //sezten wir den Zeiger head auf das erste Element
        }
    }
    public void AddEnd(string name)
    {
        Wrapper newElement = new Wrapper(new Student(name)); //das  hinzuzufügende Element
        if (head == null) //wenn die Liste Leer ist
            head = tail = newElement;
        else //die Liste nicht Leer ... wir wollen durch die Liste bis zu Ende laufen und das Element hinzufügen
        {
            newElement.prev = tail; //newElement zeigt auf das letzte Element ... tail <= irgendwas
            tail.next = newElement; // tail => <= irgendwass ... tail zeigt auch jetzt auf newElement
            tail = newElement; //setzten wir den zeiger tail auf das letzte Element

        } // fertig!!



    }
    public void AddSort(string name)
    {
        Wrapper newElement = new Wrapper(new Student(name));
        if (head == null) //leere Liste
            head = tail = newElement;
        else if (newElement.stu.CompareTo(head.stu) < 0) //Dass Element soll Am Anfang geschrieben werden 
        {//genau so wie add am Anfang
            newElement.next = head;
            head.prev = newElement;
            head = newElement;
            //du kannst auch hier nur diese Linie schreiben AddFirst(name);
            //AddFirst(name); &_&
        }
        else
        {
            Wrapper temp = head; //Copy of the zeiger
            bool success = false; //wenn das Element noch nicht hinzufügt, ist success immer false
            while (temp != null && !success)
            {
                if (temp.stu.CompareTo(newElement.stu) == 0) //das Element ist schon vorhanden, dann setzen wir sucess = true
                    success = true;
                else if (newElement.stu.CompareTo(temp.stu) < 0)
                {
                    //zuerst soll das neueElement auf temp und was vor temp steht zeigen
                    //dann was vor temp steht, soll auf newElement zeigen
                    //dann temp.prev soll auf newElement zeigen ... schau mal den Code
                    newElement.next = temp; //temp.prev.next und newElement.next zeigen jetzt auf temp
                    newElement.prev = temp.prev; //newElement.prev zeigt auf temp.prev
                    temp.prev.next = newElement; //was vor temp steht zeigt auf newElement
                    temp.prev = newElement; //temp.prev zeigt auf das neue Element
                    success = true;
                }
                temp = temp.next;
            }
            if (!success) //wenn sucess == False ... dann das Element noch nicht hinzufgt und wir sollen es am Ende addieren
            {
                AddEnd(name);
            }

        }
    }

    public void Remove(string name) //ich werde löschen, wenn zwei Namen gleich sind!! 
                                    //wenn wir das noch spezialisieren sollen, sollen wir IEquatable implementieren
    {
        if (head != null)
        {
            if (head.stu.name == name) // wenn das Erste Element wäre
            {
                head = head.next;
            }
            else // wenn Element in der Mitte ist
            {
                Wrapper temp = head;
                bool success = false;
                while (temp.next != null && !success) //wir untersuchen bis das letzte Element
                                                      //das letzte Element untersuchen wir allein, weil es dort ein Zeiger tail heißt!!
                {
                    if (temp.stu.name == name)
                    {
                        temp.prev.next = temp.next;
                        success = true;
                    }
                    temp = temp.next;
                }
                if (!success) //wenn wir noch kein Element gelöscht haben
                              //dass es könnte sein, dass das Element das letzte ist
                {
                    if (tail.stu.name == name)
                    {
                        tail = tail.prev; //tail Zeiger auf das vorherige Element setzen
                        tail.next = null; // was nach tail null wird
                    }

                }
            }
        }

    }

    public IEnumerator GetEnumerator()
    {
        for (Wrapper temp = head; temp != null; temp = temp.next)
        {
            yield return temp.stu;
        }
    }
}
}
