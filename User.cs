// Class to create the user object

class User 
{
    private string username;
    private string password;
    private string address;
    private string creditCardNum;

    public User(string address, string creditCardNum, string username = "default", string password = "CLEAR") 
    {
        this.username = username;
        this.password = password;
        this.address = address;
        this.creditCardNum = creditCardNum;
    } 
}