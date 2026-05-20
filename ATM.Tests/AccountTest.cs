namespace ATM.ATM.Tests;

using Xunit;

public class AccountTest
{

    Account account;

    [Fact]
    public void CreateAccountTest()
    {
        int initialBalance = 5000;
        Account account = new Account(initialBalance);
        Assert.IsType<Account>(account);
        Assert.Equal(5000, account.GetBalance());
    }

    // Helper method (text fixture)
    private void CreateAccountTestHelper()
    {
        int initialBalance = 5000;
        account = new Account(initialBalance);
    }

    [Fact]
    public void WithdrawTest()
    {
        // setup
        CreateAccountTestHelper();
        // test
        Assert.Equal(5000, account.GetBalance());
        bool successfulWithdrawal = account.Withdraw(1000);
        Assert.True(successfulWithdrawal);
        Assert.Equal(4000, account.GetBalance());
    }



}
