using System.Collections.Generic;

public class Project
{
    string pName;
    int pId;
    SalariedEmployee manager;
    List<Task> projTasks = new List<Task>();

    public Project(string name, int id)
    {
        pName = name;
        pId = id;
    }

    public int getId()
    {
        return pId;
    }
    //Pid, P Name     , P Location       , P Manager id
    public Project(string[] data)
    {
        pName = data[1].Trim();
        pId = int.Parse(data[0].Trim());
    }
    public void setProjManager(SalariedEmployee e)
    {
        manager = e;

    }
    public SalariedEmployee getProjManager()
    {
        return manager;
    }


}


public class Task
{
    public int tID { set; get; }
    string tDescription;
    public float eHourlyCost { set; get; }
    public float hoursWorked { set; get; }
    string tBegin;
    string tEnd;


    public Task(int tID, string tDescription, float eHourlyCost, float wh, string tBegin, string tEnd)
    {
        this.tID = tID;
        this.tDescription = tDescription;
        this.eHourlyCost = eHourlyCost;
        hoursWorked = wh;
        this.tBegin = tBegin;
        this.tEnd = tEnd;
    }

    public override bool Equals(object obj)
    {
        var task = obj as Task;
        return task != null &&
               tID == task.tID;
    }
}

public class WorksOn
{
    Project project;
    Employee Emp;
    string startDate;
    string endDate;
    List<Task> assignedTasks;

    public WorksOn(Project p, Employee e, float wh, string sDate, string eDate)
    {
        project = p;
        Emp = e;
        assignedTasks = new List<Task>();

        startDate = sDate;
        endDate = eDate;
    }

    public Project getProject(){
        return project;
    }

    public Employee getEmployee(){
        return Emp;
    }
    public void assignTaskToEmployee(Task t)
    {
        assignedTasks.Add(t);
    }
}