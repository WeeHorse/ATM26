namespace ATM.ATM.Tests;

using System.Reflection.Metadata;
using Xunit;

public class AtmServiceTest
{
  AtmService atm;

  private void AuthenticateHelper()
  {
    Account account = new Account(5000);
    Card card = new Card("1234-5678", "1234", account);
    atm = new AtmService(11000);
    atm.InsertCard(card);
    atm.EnterPin("1234");
  }

  [Theory]
  [InlineData(1000, 4000, true)]
  [InlineData(6000, 5000, false)] // kan inte ta ut 6000 när jag har 5000 på kortet
  [InlineData(12000, 5000, false)] // kan inte ta ut 12000 när det finns 11000 på bankomaten
  [InlineData(0, 5000, true)] // kan jag ta ut 0 kr?
  [InlineData(-1000, 5000, false)] // kan inte ta -1000 kr, det vore en insättning
  public void WithdrawTest(int withdrawal, int remainingBalance, bool expectedResult)
  {
    AuthenticateHelper();
    bool result = atm.Withdraw(withdrawal);
    Assert.Equal(remainingBalance, atm.GetBalance());
    Assert.Equal(expectedResult, result);
  }

}