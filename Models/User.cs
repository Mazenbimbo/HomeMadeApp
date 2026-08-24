public class User{
    public enum roles {
        Admin,
        Saler,
        Delivary,
        Customer
    }

    private int internal_ID =1;

    public int ID{set;get;}
    public string Name{set;get;}
    public roles Role{set;get;}
 

 public User(string name, roles role){
    ID = internal_ID;
    internal_ID++;

    Role = roles.Customer;
}
}

