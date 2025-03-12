using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) nao e suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) nao e suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_0_Ao_Mutar()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AlternarModoMudo();
        Assert.AreEqual(0, televisao.Volume);
    }


    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;
        

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }
   [TestMethod]
    public void Deve_Criar_Instancia_Com_Canal_500()
    {
        const int canalPadrao = 500;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(canalPadrao, televisao.Canal);
    }

    [TestMethod]
    public void Deve_Ter_Canal_501_Apos_Aumentar_Canal()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarCanal();
        Assert.AreEqual(501, televisao.Canal);
    }

    [TestMethod]
    public void Deve_Ter_Canal_499_Apos_Diminuir_Canal()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirCanal();
        Assert.AreEqual(499, televisao.Canal);
    }

    [TestMethod]
    public void TrocarCanal_Deve_Ajustar_Canal_Para_Minimo_Se_Canal_For_Menor_Que_Minimo()
    {
        Televisao televisao = new Televisao(25f);
        int canalDigitado = 299;
        televisao.TrocarCanal(canalDigitado);
        Assert.AreEqual(300, televisao.Canal);

    }
    
    [TestMethod]

    public void TrocarCanal_Deve_Ajustar_Canal_Para_Maximo_Se_Canal_For_Maior_Que_Maximo()
    {
        Televisao televisao = new Televisao(25f);
        int canalDigitado = 601;
        televisao.TrocarCanal(canalDigitado);
        Assert.AreEqual(600, televisao.Canal);
    }

    [TestMethod]
    public void TrocarCanal_Deve_Manter_Canal_Se_Estiver_Dentro_Do_Intervalo()
    {
        Televisao televisao = new Televisao(25f);
        int canalDigitado = 501;
        televisao.TrocarCanal(canalDigitado);
        Assert.AreEqual(canalDigitado, televisao.Canal);
    }
}
