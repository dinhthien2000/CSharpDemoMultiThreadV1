using DemoMultiThread.Dao;
using DemoMultiThread.Model;
using System.Collections.Generic;

internal class Program
{
    // nếu hàm main trả về kiểu void sẽ dính Lỗi CS5001 Chương trình không chứa phương thức 'Chính' tĩnh phù hợp với điểm vào DemoMultiThread
    // Nên phải dùng Task làm kiểu trả về
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

                shortBeginProcess();

                say();

                //// Get
                //list = retrieveAll();
                //display(await list.ConfigureAwait(false));

                //// Create
                //emp = new Employee(i, "thien", "22"); //await sẽ đợi phương thức bất đồng bộ trả về giá trị mới thực thi tiếp
                //                                      //(luồng sẽ dừng lại, ở đây luồng main dừng luôn nên không thể hiện được bất đồng bộ mình muốn là mạnh hoạt động nào nó chạy
                //                                      //(thêm, xóa, sửa, hiển thị, chạy không đồng bộ)) 
                //employee = createEmployee(emp);
                //display(await employee.ConfigureAwait(false));

                //// Update
                //emp.Name = "thien" + i;
                //employee = updateEmployee(emp);
                //display(await employee.ConfigureAwait(false)); // await sẽ đợi phương thức bất đồng bộ trả về giá trị

                //emp = new Employee(i, "thien", "22");
                //retrieveAll();
                createEmployee();
                updateEmployee();



                // Delete
                /* if (i > 60 && i %2 == 0){
                    id = removeEmployee(i - index);
                    Console.WriteLine(await id.ConfigureAwait(false));
                    index++;
                    Console.WriteLine(index);
                }*/


                shortEndProcess();
            retrieveAll();
        }
           
            // sau khi test bất đồng bộ thành công xóa hết dữ liệu
            //deleteFrom();
            
      
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }

        // List<Employee> employees = await Task.Run( () => return list ); //Vì 'Program.Main(string[])' là một phương thức không đồng bộ trả về 'Tác vụ',
                                                                           //nên một từ khóa trả về không được theo sau bởi một biểu thức đối tượng DemoMultiThread
        //List<Employee> employees = await Task.Run(() => list );
        //Console.WriteLine("Số lượng employees: "+employees.Count);

        

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
    static async Task retrieveAll() { 
        EmployeeDao dao = new EmployeeDao();
        
        List<Employee> list =  dao.retrieveAllEmployes();

        display(list);
    
    }


    static async Task createEmployee()
    {
        EmployeeDao dao = new EmployeeDao();
        Employee emp;
        for (int i = 1; i < 1001; i++)
        {
            emp = new Employee(i, "thien", "22");
            Employee employeeCreate = dao.createEmployes(emp);
            //retrieveAll();
        }
        

       
        
        
    }


    static async Task updateEmployee()
    {
        EmployeeDao dao = new EmployeeDao();
        Employee emp;
        for (int i = 1; i < 1001; i++)
        {
            emp = new Employee(i, "thien"+i, "22");
            Employee employeeUpdate = dao.updateEmployes(emp);
            //retrieveAll();
        }
    }

    static async Task<int> removeEmployee(int id)
    {
        EmployeeDao dao = new EmployeeDao();

        Object employeeRemove = dao.removeEmployes(id);

        return (int)employeeRemove;
    }


}