public class main
{

    // https://stackoverflow.com/questions/5124743/algorithm-for-simplifying-decimal-to-fractions
    // převede floating point number na zlomek
    static string double_to_fract(double x, double error = 0.00001)
    {
        double n = (int) Math.Floor(x);
        x -= n;
        if (x < error)
            return String.Format("{0}/{1}", n, 1);
        else if( 1 - error < x)
            return String.Format("{0}/{1}", n+1, 1);


        double lower_n = 0;
        double lower_d = 1;

        double upper_n = 1;
        double upper_d = 1;
        while (true)
        {
            double middle_n = lower_n + upper_n;
            double middle_d = lower_d + upper_d;
            if (middle_d * (x + error) < middle_n){
                upper_n = middle_n;
                upper_d = middle_d;
            }
            else if (middle_n < (x - error) * middle_d){
                lower_n = middle_n;
                lower_d = middle_d;
            }
            else
            {
                return String.Format("{0}/{1}", n * middle_d + middle_n, middle_d);
            }
        }

    }

    static double SoucetZlomku(List<double> citatele, List<double> jmenovatele)
    {

        double sum = 0;
        for(int i = 0; i < citatele.Count; i++){
            sum += citatele[i] / jmenovatele[i];
        }
        return sum;
    }

    public static void Main()
    {
        List<double> citatele = new List<double>();
        List<double> jmenovatele = new List<double>();
        while (true){
            Console.Write("Zadejte zlomek nebo x pro ukončení výběru: ");
            string zlomek = Console.ReadLine();
            string[] split = zlomek.Split("/");
            if (zlomek == "x" || zlomek == ""){
                break;
            }
            // ujistit se zlomek ma čitatele i jmenovatele 
            if (split.Length != 2){
                Console.WriteLine("Zadaný zlomek není platný");
            }
            if (split[1] == "0"){
                Console.WriteLine("jmenovatel nemůže být 0");
                continue;
            }
            else{
                citatele.Add(double.Parse(split[0]));
                jmenovatele.Add(double.Parse(split[1]));
            }
        }


        double soucet = SoucetZlomku(citatele, jmenovatele);
        Console.WriteLine(String.Format("Výsledek je: {0} = {1}", double_to_fract(soucet), Math.Round(soucet, 6)));
    }
}