namespace Brimborium.Werkzeugkasten.Powershell.Test;

public class PowershellTest {
    [Fact]
    public void WKAppHostTest01() {
        PowershellUtility.ExecutePowershell("WKAppHostTest01.ps1");
    }
}
