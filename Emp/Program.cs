using System;
using System.Collections.Generic;

namespace Emp
{
    class Program
    {



        public static void listAllEmpPayInfo(char eType, List<Object> eList){

                       
            //To print the information as a Table with header
            //first: print the header 
            if(eType=='T'){
                Console.WriteLine("\n\n{0,-20} {1,-10} {2,-10} {3,-10}","Name","hWorked","Wage/h","Net Pay");
                //2ND: print line after the header
                Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10}","--------------------","----------","----------","----------");
            }
            else{
                Console.WriteLine("\n\n{0,-20} {1,-10} {2,-10} {3,-10}","Name","Base Sal.","Bonus","Net Pay");
                //2ND: print line after the header
                Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10}","--------------------","----------","----------","----------");
            }

            // to send printPaySlip() message to each employee in the list
            foreach(Employee emp in eList ){
                //emp.displEmpInfo();
                emp.printPaySlip();
            }


        }


        public static void LoadData(char Datatype, List<Object> list, string fileName, bool headerIncluded)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            // s1= new GradStudent("aaaa", 2.2F, "ssss", "dddd", 3.55f);
            // Display the file contents by using a foreach loop.
            //System.Console.WriteLine("File Student List = ");
            int i = 0;
            if (!headerIncluded) i=1;
            foreach (string line in lines)
            {
                string[] sData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    if (Datatype == 'T') //tempEmpl
                        list.Add(new TempEmployee(sData));
                    if (Datatype == 'S')
                        list.Add(new SalariedEmployee(sData));
                    if (Datatype == 'P') //proj    Pid, P Name     , P Location       , P Manager id
                        {
                         var p = new Project(sData);
                         list.Add(p);
                        }

                    
                }
                i++;
            }
        }

     public static  Employee getEmplById(int eid, List<Employee> el){
         foreach(var e in el)
            if(e.getId() == eid)
                return e;
        return null;        
     }

      public static  Employee getEmplByName(string ename, List<Employee> el){
         foreach(var e in el)
            if(e.getName() == ename)
                return e;
        return null;        
     }

     public static  Project getProjById(int pid, List<Project> pl){
         foreach(var p in pl)
            if(p.getId() == pid)
                return p;
        return null;        
     }

    public static void LoadProjMangers(List<Employee> el,List<Project> pl, string fileName, bool headerIncluded)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            // s1= new GradStudent("aaaa", 2.2F, "ssss", "dddd", 3.55f);
            // Display the file contents by using a foreach loop.
            //System.Console.WriteLine("File Student List = ");
            int i = 0;
            if (!headerIncluded) i=1;
            foreach (string line in lines)
            {
                string[] sData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                int pid = int.Parse(sData[0].Trim());
                int eid = int.Parse(sData[1].Trim());
                Employee e = getEmplById(eid, el);
                Project p = getProjById(pid, pl);
                if(e != null && p !=null)
                    p.setProjManager((SalariedEmployee)e);
                             
                }
                i++;
            }
            
        }

         public static void LoadEmpProjAssignment(List<Employee> el,List<Project> pl, List<WorksOn> ea, string fileName, bool headerIncluded)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            // s1= new GradStudent("aaaa", 2.2F, "ssss", "dddd", 3.55f);
            // Display the file contents by using a foreach loop.
            //System.Console.WriteLine("File Student List = ");
            int i = 0;
            if (!headerIncluded) i=1;
            foreach (string line in lines)
            {
                string[] sData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                int pid = int.Parse(sData[0].Trim());
                int eid = int.Parse(sData[1].Trim());
                Employee e = getEmplById(eid, el);
                Project p = getProjById(pid, pl);
                if(e != null && p !=null)
                    ea.Add(new WorksOn( p,  e,  10f, "2/2/2001", ""));
                             
                }
                i++;
            }
            
        }

        static void Main(string[] args)
        {
            // declaring a List of type TempEmployee to store the objects
            List<Object> tmp = new List<object>();
            var tmpList = new List<Employee>();
            //we can do the same for the other class (SalariedEmployee) 
            List<Employee> salList = new List<Employee>();
            List<Project> ourProjects = new List<Project>();
            List<WorksOn> employeeProjAssignments = new List<WorksOn>();

            // add new employee object directly to the list using some values
            tmpList.Add(new TempEmployee("John"," 1200 s westren st, Canyon",22, 40f, 15.5f));

            //create employee object using some values, then add the created object to the list
            var e = new TempEmployee("Nick"," 333 Bill st, Amarillo",26, 50f, 15.5f);
            tmpList.Add(e);
            Project p1 = new Project("WT Stadium",11);
            SalariedEmployee  a = new SalariedEmployee("Bob"," 233 Bill st, Amarillo",33,5000f,1200f);
            // read some employees info from the cosole "keyboard input", then add them to the list

            p1.setProjManager(a);
            SalariedEmployee t = p1.getProjManager();
            t.displEmpInfo();
        
          


            // To read employees data from file, where each line has one employee info separated by comma ","
            // the employee information is in the file tempEmployee.txt which is in the main directory of this project 
            
            LoadData('T',tmp,"tempEmployees.txt",false);
             
            tmpList.AddRange(tmp.ConvertAll(x => (TempEmployee)x));
           tmp = new List<Object>();
            LoadData('S',tmp,"salEmployees.txt",false);
           salList.AddRange(tmp.ConvertAll(x => (SalariedEmployee)x));

            tmp = new List<Object>();
            LoadData('P',tmp,"projectsData.txt",true);
            ourProjects.AddRange(tmp.ConvertAll(x => (Project)x));



            tmp = new List<Object>();
            tmp.AddRange(salList.ConvertAll(x => (Object)x));
            tmp.AddRange(tmpList.ConvertAll(x => (Object)x));
            listAllEmpPayInfo('S', tmp);

            //LoadProjMangers(List<Employee> el,List<Project> pl, string fileName, bool headerIncluded)
            LoadProjMangers(salList,ourProjects, "projManagers.txt", true);
            LoadEmpProjAssignment(salList,ourProjects,employeeProjAssignments,"worksOn.txt",true);
            foreach(Project p in ourProjects){
                Console.WriteLine("Project info for:");
                p.getProjManager().displEmpInfo();
                Console.WriteLine(" Has the following Employees:");
                foreach(WorksOn epa in employeeProjAssignments){
                    Project tp = epa.getProject();
                    if(tp == p)
                        epa.getEmployee().displEmpInfo();
                }

            }

        }
    }
}
