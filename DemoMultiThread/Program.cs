using DemoMultiThread.Dao;
using DemoMultiThread.Model;
using System.Collections.Generic;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // các thể hiện này sẽ hứng các giá trị trả về từ các phương thức có kiểu trả về tương ứng.
        Task<Employee> employee = null; 
        Task<List<Employee>> list = null;
        Task<int> id = null;
        int index = 1;
        Employee emp = null;

        try
        {
            for (int i = 1; i < 101; i++)
            {
                shortBeginProcess();

                say();

                // Get
                list = retrieveAll();
                display(await list.ConfigureAwait(false));

                // Create
                emp = new Employee(i, "thien", "22"); //await sẽ đợi phương thức bất đồng bộ trả về giá trị mới thực thi tiếp
                                                      //(luồng sẽ dùng lại, ở đây luồng main dùng luôn nên không thể hiện được bất đồng bộ mình muốn là mạnh hoạt động nào nó chạy
                                                      //(thêm, xóa, sửa, hiển thị, chạy không đồng bộ)) 
                employee = createEmployee(emp);
                display(await employee.ConfigureAwait(false));

                // Update
                emp.Name = "thien" + i;
                employee = updateEmployee(emp);
                display(await employee.ConfigureAwait(false)); // await sẽ đợi phương thức bất đồng bộ trả về giá trị

                // Delete
                /* if (i > 60 && i %2 == 0){
                    id = removeEmployee(i - index);
                    Console.WriteLine(await id.ConfigureAwait(false));
                    index++;
                    Console.WriteLine(index);
                }*/

                
                shortEndProcess();
            }
           
            // sau khi test bất đồng bộ thành công xóa hết dữ liệu
            //deleteFrom();
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }

        // List<Employee> employees = await Task.Run( () => return list ); //Vì 'Program.Main(string[])' là một phương thức không đồng bộ trả về 'Tác vụ',
                                                                           //nên một từ khóa trả về không được theo sau bởi một biểu thức đối tượng DemoMultiThread
        List<Employee> employees = await Task.Run(() => list );
        Console.WriteLine("Số lượng employees: "+employees.Count);

        

    }


    static void shortBeginProcess()
    {
        Console.WriteLine("Hello world");
        Console.WriteLine("This is synchronized begin");
    }

    static void shortEndProcess()
    {
        Console.WriteLine("End ----- HEHE ^^");
        Console.WriteLine("This is synchronized end");
        Console.WriteLine("-------------- \n");
    }

    // phương thức bất đồng bộ kiểu void không cần trả về
    static async void say()
    {
        //Console.WriteLine("Trying to yeye ^^ !!");
        Console.WriteLine("Asynchronized type return is void ^^ !!");
    }


    /*           CRUD              */

    static void display(List<Employee> list)
    {
        foreach (Employee obj in list)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    static void display(Employee obj)
    {

        Console.WriteLine(obj.ToString());
        
    }

    static void deleteFrom()
    {
        EmployeeDao dao = new EmployeeDao();

        dao.removeAllEmployes();

    }


    // Khi phương thức muống trả về giá trị thì phải sài kiểu Task<> generic (VD : Task<List<Employee>> trả về generic Task list employee )
    static async Task<List<Employee>> retrieveAll() { 
        EmployeeDao dao = new EmployeeDao();
        
        List<Employee> list =  dao.retrieveAllEmployes();

        return  list;
    
    }


    static async Task<Employee> createEmployee(Employee employee)
    {
        EmployeeDao dao = new EmployeeDao();

        Employee employeeCreate = dao.createEmployes(employee);

        return employeeCreate;
    }


    static async Task<Employee> updateEmployee(Employee employee)
    {
        EmployeeDao dao = new EmployeeDao();

        Employee employeeUpdate = dao.updateEmployes(employee);

        return employeeUpdate;
    }

    static async Task<int> removeEmployee(int id)
    {
        EmployeeDao dao = new EmployeeDao();

        Object employeeRemove = dao.removeEmployes(id);

        return (int)employeeRemove;
    }


}