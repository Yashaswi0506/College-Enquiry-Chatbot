using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Speech.Synthesis;

public partial class Inquiry : System.Web.UI.Page
{
    //  public static string pqr = null;
    // public static string searchtxt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Visible = false;
       
    }
    public class Porter2
    {

        string[] doubles = { "bb", "dd", "ff", "gg", "mm", "nn", "pp", "rr", "tt" };
        string[] validLiEndings = { "c", "d", "e", "g", "h", "k", "m", "n", "r", "t" };

        private string[,] step1bReplacements =
        {
            {"eedly","ee"},
            {"ingly",""},
            {"edly",""},
            {"eed","ee"},
            {"ing",""},
            {"ed",""}
        };

        string[,] step2Replacements =
        {
            {"ization","ize"},
            {"iveness","ive"},
            {"fulness","ful"},
            {"ational","ate"},
            {"ousness","ous"},
            {"biliti","ble"},
            {"tional","tion"},
            {"lessli","less"},
            {"fulli","ful"},
            {"entli","ent"},
            {"ation","ate"},
            {"aliti","al"},
            {"iviti","ive"},
            {"ousli","ous"},
            {"alism","al"},
            {"abli","able"},
            {"anci","ance"},
            {"alli","al"},
            {"izer","ize"},
            {"enci","ence"},
            {"ator","ate"},
            {"bli","ble"},
            {"ogi","og"},
            {"li",""}
        };

        string[,] step3Replacements =
        {
            {"ational","ate"},
            {"tional","tion"},
            {"alize","al"},
            {"icate","ic"},
            {"iciti","ic"},
            {"ative",""},
            {"ical","ic"},
            {"ness",""},
            {"ful",""}
        };

        string[] step4Replacements =            
            {"ement",
            "ment",
            "able",
            "ible",
            "ance",
            "ence",
            "ate",
            "iti",
            "ion",
            "ize",
            "ive",
            "ous",
            "ant",
            "ism",
            "ent",
            "al",
            "er",
            "ic"
        };

        string[,] exceptions =
        {
        {"skis","ski"},
        {"skies","sky"},
        {"dying","die"},
        {"lying","lie"},
        {"tying","tie"},
        {"idly","idl"},
        {"gently","gentl"},
        {"ugly","ugli"},
        {"early","earli"},
        {"only","onli"},
        {"singly","singl"},
        {"sky","sky"},
        {"news","news"},
        {"howe","howe"},
        {"atlas","atlas"},
        {"cosmos","cosmos"},
        {"bias","bias"},
        {"andes","andes"}
        };

        string[] exceptions2 =
        {"inning","outing","canning","herring","earring","proceed",
            "exceed","succeed"};


        // A helper table lookup code - used for vowel lookup 
        private bool arrayContains(string[] arr, string s)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == s) return true;
            }
            return false;
        }

        private bool isVowel(StringBuilder s, int offset)
        {
            switch (s[offset])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'y':
                    return true;
                    break;
                default:
                    return false;
            }
        }

        private bool isShortSyllable(StringBuilder s, int offset)
        {
            if ((offset == 0) && (isVowel(s, 0)) && (!isVowel(s, 1)))
                return true;
            else
                if (
                    ((offset > 0) && (offset < s.Length - 1)) &&
                    isVowel(s, offset) && !isVowel(s, offset + 1) &&
                    (s[offset + 1] != 'w' && s[offset + 1] != 'x' && s[offset + 1] != 'Y')
                    && !isVowel(s, offset - 1))
                    return true;
                else
                    return false;
        }

        private bool isShortWord(StringBuilder s, int r1)
        {
            if ((r1 >= s.Length) && (isShortSyllable(s, s.Length - 2))) return true;

            return false;
        }

        private void changeY(StringBuilder sb)
        {
            if (sb[0] == 'y') sb[0] = 'Y';

            for (int i = 1; i < sb.Length; ++i)
            {
                if ((sb[i] == 'y') && (isVowel(sb, i - 1))) sb[i] = 'Y';
            }
        }

        private void computeR1R2(StringBuilder sb, ref int r1, ref int r2)
        {
            r1 = sb.Length;
            r2 = sb.Length;

            if ((sb.Length >= 5) && (sb.ToString(0, 5) == "gener" || sb.ToString(0, 5) == "arsen")) r1 = 5;
            if ((sb.Length >= 6) && (sb.ToString(0, 6) == "commun")) r1 = 6;

            if (r1 == sb.Length) // If R1 has not been changed by exception words
                for (int i = 1; i < sb.Length; ++i) // Compute R1 according to the algorithm
                {
                    if ((!isVowel(sb, i)) && (isVowel(sb, i - 1)))
                    {
                        r1 = i + 1;
                        break;
                    }
                }

            for (int i = r1 + 1; i < sb.Length; ++i)
            {
                if ((!isVowel(sb, i)) && (isVowel(sb, i - 1)))
                {
                    r2 = i + 1;
                    break;
                }
            }
        }

        private void step0(StringBuilder sb)
        {

            if ((sb.Length >= 3) && (sb.ToString(sb.Length - 3, 3) == "'s'"))//singles
                sb.Remove(sb.Length - 3, 3);
            else
                if ((sb.Length >= 2) && (sb.ToString(sb.Length - 2, 2) == "'s"))
                    sb.Remove(sb.Length - 2, 2);
                else
                    if (sb[sb.Length - 1] == '\'')
                        sb.Remove(sb.Length - 1, 1);
        }

        private void step1a(StringBuilder sb)
        {

            if ((sb.Length >= 4) && sb.ToString(sb.Length - 4, 4) == "sses")
                sb.Replace("sses", "ss", sb.Length - 4, 4);
            else
                if ((sb.Length >= 3) && (sb.ToString(sb.Length - 3, 3) == "ied" || sb.ToString(sb.Length - 3, 3) == "ies"))
                {
                    if (sb.Length > 4)
                        sb.Replace(sb.ToString(sb.Length - 3, 3), "i", sb.Length - 3, 3);
                    else
                        sb.Replace(sb.ToString(sb.Length - 3, 3), "ie", sb.Length - 3, 3);
                }
                else
                    if ((sb.Length >= 2) && (sb.ToString(sb.Length - 2, 2) == "us" || sb.ToString(sb.Length - 2, 2) == "ss"))
                        return;
                    else
                        if ((sb.Length > 0) && (sb.ToString(sb.Length - 1, 1) == "s"))
                        {
                            for (int i = 0; i < sb.Length - 2; ++i)
                                if (isVowel(sb, i))
                                {
                                    sb.Remove(sb.Length - 1, 1);
                                    break;
                                }
                        }

        }

        private void step1b(StringBuilder sb, int r1)
        {
            for (int i = 0; i < 6; ++i)
            {
                if ((sb.Length > step1bReplacements[i, 0].Length) && (sb.ToString(sb.Length - step1bReplacements[i, 0].Length, step1bReplacements[i, 0].Length) == step1bReplacements[i, 0]))
                {
                    switch (step1bReplacements[i, 0])
                    {
                        case "eedly":
                        case "eed":
                            if (sb.Length - step1bReplacements[i, 0].Length >= r1)
                                sb.Replace(step1bReplacements[i, 0], step1bReplacements[i, 1], sb.Length - step1bReplacements[i, 0].Length, step1bReplacements[i, 0].Length);
                            break;
                        default:
                            bool found = false;
                            for (int j = 0; j < sb.Length - step1bReplacements[i, 0].Length; ++j)
                            {
                                if (isVowel(sb, j))
                                {
                                    sb.Replace(step1bReplacements[i, 0], step1bReplacements[i, 1], sb.Length - step1bReplacements[i, 0].Length, step1bReplacements[i, 0].Length);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) return;
                            switch (sb.ToString(sb.Length - 2, 2))
                            {
                                case "at":
                                case "bl":
                                case "iz":
                                    sb.Append("e");
                                    return;
                            }
                            if (arrayContains(doubles, sb.ToString(sb.Length - 2, 2)))
                            {
                                sb.Remove(sb.Length - 1, 1);
                                return;
                            }
                            if (isShortWord(sb, r1))
                                sb.Append("e");
                            break;
                    }
                    return;
                }
            }
        }

        private void step1c(StringBuilder sb)
        {
            if ((sb.Length > 0) &&
                (sb[sb.Length - 1] == 'y' || sb[sb.Length - 1] == 'Y') &&
                (sb.Length > 2) && (!isVowel(sb, sb.Length - 2))
               )
                sb[sb.Length - 1] = 'i';
        }

        private void step2(StringBuilder sb, int r1)
        {
            for (int i = 0; i < 24; ++i)
            {
                if (
                    (sb.Length >= step2Replacements[i, 0].Length) &&
                    (sb.ToString(sb.Length - step2Replacements[i, 0].Length, step2Replacements[i, 0].Length) == step2Replacements[i, 0])
                    )
                {
                    if (sb.Length - step2Replacements[i, 0].Length >= r1)
                    {
                        switch (step2Replacements[i, 0])
                        {
                            case "ogi":
                                if ((sb.Length > 3) &&
                                    (sb[sb.Length - step2Replacements[i, 0].Length - 1] == 'l')
                                    )
                                    sb.Replace(step2Replacements[i, 0], step2Replacements[i, 1], sb.Length - step2Replacements[i, 0].Length, step2Replacements[i, 0].Length);
                                return;
                            case "li":
                                if ((sb.Length > 1) &&
                                    (arrayContains(validLiEndings, sb.ToString(sb.Length - 3, 1)))
                                    )
                                    sb.Remove(sb.Length - 2, 2);
                                return;
                            default:
                                sb.Replace(step2Replacements[i, 0], step2Replacements[i, 1], sb.Length - step2Replacements[i, 0].Length, step2Replacements[i, 0].Length);
                                return;
                                break;

                        }
                    }
                    else
                        return;
                }
            }
        }

        private void step3(StringBuilder sb, int r1, int r2)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (
                    (sb.Length >= step3Replacements[i, 0].Length) &&
                    (sb.ToString(sb.Length - step3Replacements[i, 0].Length, step3Replacements[i, 0].Length) == step3Replacements[i, 0])
                    )
                {
                    if (sb.Length - step3Replacements[i, 0].Length >= r1)
                    {
                        switch (step3Replacements[i, 0])
                        {
                            case "ative":
                                if (sb.Length - step3Replacements[i, 0].Length >= r2)
                                    sb.Replace(step3Replacements[i, 0], step3Replacements[i, 1], sb.Length - step3Replacements[i, 0].Length, step3Replacements[i, 0].Length);
                                return;
                            default:
                                sb.Replace(step3Replacements[i, 0], step3Replacements[i, 1], sb.Length - step3Replacements[i, 0].Length, step3Replacements[i, 0].Length);
                                return;
                        }
                    }
                    else return;
                }
            }
        }

        private void step4(StringBuilder sb, int r2)
        {
            for (int i = 0; i < 18; ++i)
            {
                if (
                    (sb.Length >= step4Replacements[i].Length) &&
                    (sb.ToString(sb.Length - step4Replacements[i].Length, step4Replacements[i].Length) == step4Replacements[i])                    // >=
                    )
                {
                    if (sb.Length - step4Replacements[i].Length >= r2)
                    {
                        switch (step4Replacements[i])
                        {
                            case "ion":
                                if (
                                    (sb.Length > 3) &&
                                    (
                                        (sb[sb.Length - step4Replacements[i].Length - 1] == 's') ||
                                        (sb[sb.Length - step4Replacements[i].Length - 1] == 't')
                                    )
                                   )
                                    sb.Remove(sb.Length - step4Replacements[i].Length, step4Replacements[i].Length);
                                return;
                            default:
                                sb.Remove(sb.Length - step4Replacements[i].Length, step4Replacements[i].Length);
                                return;
                        }
                    }
                    else
                        return;
                }
            }

        }

        private void step5(StringBuilder sb, int r1, int r2)
        {
            if (sb.Length > 0)
                if (
                    (sb[sb.Length - 1] == 'e') &&
                    (
                        (sb.Length - 1 >= r2) ||
                        ((sb.Length - 1 >= r1) && (!isShortSyllable(sb, sb.Length - 3)))
                    )
                   )
                    sb.Remove(sb.Length - 1, 1);
                else
                    if (
                        (sb[sb.Length - 1] == 'l') &&
                            (sb.Length - 1 >= r2) &&
                            (sb[sb.Length - 2] == 'l')
                        )
                        sb.Remove(sb.Length - 1, 1);
        }

        public string stem(string word)
        {
            if (word.Length < 3) return word;

            StringBuilder sb = new StringBuilder(word.ToLower());

            if (sb[0] == '\'') sb.Remove(0, 1);

            for (int i = 0; i < exceptions.Length / 2; ++i)
                if (word == exceptions[i, 0])
                    return exceptions[i, 1];

            int r1 = 0, r2 = 0;
            changeY(sb);
            computeR1R2(sb, ref r1, ref r2);

            step0(sb);
            step1a(sb);

            for (int i = 0; i < exceptions2.Length; ++i)
                if (sb.ToString() == exceptions2[i])
                    return exceptions2[i];

            step1b(sb, r1);
            step1c(sb);
            step2(sb, r1);
            step3(sb, r1, r2);
            step4(sb, r2);
            step5(sb, r1, r2);


            return sb.ToString().ToLower();
        }

        public string stempdf(string word)
        {
            if (word.Length < 3) return word;

            StringBuilder sb = new StringBuilder(word.ToLower());

            if (sb[0] == '\'') sb.Remove(0, 1);

            for (int i = 0; i < exceptions.Length / 2; ++i)
                if (word == exceptions[i, 0])
                    return exceptions[i, 1];

            int r1 = 0, r2 = 0;
            changeY(sb);
            computeR1R2(sb, ref r1, ref r2);

            step0(sb);
            step1a(sb);

            for (int i = 0; i < exceptions2.Length; ++i)
                if (sb.ToString() == exceptions2[i])
                    return exceptions2[i];

            step1b(sb, r1);
            step1c(sb);
            step2(sb, r1);
            step3(sb, r1, r2);
            step4(sb, r2);
            step5(sb, r1, r2);


            return sb.ToString().ToLower();
        }
    }

    // Button1.Enable=false;
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True");
    protected void TxtAskme_TextChanged(object sender, EventArgs e)
    {
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {

    
    
        try
        {
            if ((TxtAskme.Text == "syllabus") || (TxtAskme.Text == "1st year syllabus") || (TxtAskme.Text == "college syllabus"))
            {
                SearchSyllabus();
            }
            if ((TxtAskme.Text == "calender") || (TxtAskme.Text == "academic") || (TxtAskme.Text == "academic calender") || (TxtAskme.Text == "Year calender"))
            {
                SearchCalender();
            }
            if ((TxtAskme.Text == "admission") || (TxtAskme.Text == "admission form") || (TxtAskme.Text == "new admission") || (TxtAskme.Text == "entry in college"))
            {
                SearchAdmission();
            }
            if ((TxtAskme.Text == "fees") || (TxtAskme.Text == "college fees") || (TxtAskme.Text == "academic fees") || (TxtAskme.Text == "yearly fees") || (TxtAskme.Text == "charges"))
            {
                SearchFees();
            }




            // string searchtxt = TxtAskme.Text;

            string exceptions = "who where why when how what which whose whom with within without regard mgms mgm's colleges college's to yet so though while if even wherever rather wheather only well than through till towards under underneath until upon via behind below beneath beside off onto over considering consider per prior round between beyond but  much many mgm in case college details long far are the  it old come about against along is the of an by because means behalf other close despite down during due except follow forward futher inside include into inspite instead like near next as at please by from tell me i am is or our let know do did does give some help regarding was since across after before along anti around per ";
            string[] exceptionsList = exceptions.Split(' ');

            string test = TxtAskme.Text;
            string[] wordList = test.Split(' ');

            string final = null;
            var result = wordList.Except(exceptionsList).ToArray();
            final = String.Join(" ", result);
            string a1 = final;
            string pqr = null;
            string inputstem = a1;
            Porter2 stemmer = new Porter2();

            String[] ipsStrings = inputstem.Split(' ');
            foreach (var ipsString in ipsStrings)
            {

                String outputstem = stemmer.stem(ipsString);
                //textBoxfile.Text = outputstem;
                //   Console.WriteLine(ipsString + " => " + outputstem);
                String abc = null;
                abc = outputstem;
                //string pqr;
                //  string pqr;
                //  pqr=null;
                pqr = pqr + " " + abc;
                //TxtAskme.Text = abc;

            }
            //   TextBox1.Text = pqr;

            //string searchtxt1 = TxtAskme.Text;
            string searchtxt = pqr;

            SqlDataAdapter ad= null;
             ad = new SqlDataAdapter("select DISTINCT  Answer from Tbl_Info Where Question LIKE '%" + searchtxt.Replace(" ", "%' AND Question LIKE '%") + "%' ", con);
            //SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where Question LIKE '%"+searchtxt+"%'", con);
            //SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where MATCH (Question)AGAINST('%" + searchtxt + "%' IN NATURAL LANGUAGE MODE);", con);
            // SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where Question LIKE '%" + searchtxt.Replace(" ", "%' AND Question LIKE '%") + "%'", con);
            //        SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info WHERE [Question] LIKE ''%' + searchtxt.REPLACE( ' ', '%'' AND [Question] LIKE ''%') + '%''", con);
                       DataSet dst = new DataSet();
            ad.SelectCommand.Parameters.AddWithValue("@search", searchtxt);
            ad.Fill(dst, "Tbl_Info");
            if (ad != null)
            {
                GvAnswer.Visible = true;
                PnlAnswer.Visible = true;

                GvAnswer.DataSource = dst.Tables["Tbl_Info"];
                GvAnswer.DataBind();


            }
            if(GvAnswer.Visible==false)
            {
                ad = new SqlDataAdapter("select DISTINCT  Answer from Tbl_Info Where Question LIKE '%" + searchtxt.Replace(" ", "%' OR Question LIKE '%") + "%' ", con);
                //SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where Question LIKE '%"+searchtxt+"%'", con);
                //SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where MATCH (Question)AGAINST('%" + searchtxt + "%' IN NATURAL LANGUAGE MODE);", con);
                // SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info Where Question LIKE '%" + searchtxt.Replace(" ", "%' AND Question LIKE '%") + "%'", con);
                //        SqlDataAdapter ad = new SqlDataAdapter("select DISTINCT Answer from Tbl_Info WHERE [Question] LIKE ''%' + searchtxt.REPLACE( ' ', '%'' AND [Question] LIKE ''%') + '%''", con);
                 dst = new DataSet();
                ad.SelectCommand.Parameters.AddWithValue("@search", searchtxt);
                ad.Fill(dst, "Tbl_Info");
                if (ad != null)
                {
                    GvAnswer.Visible = true;
                    PnlAnswer.Visible = true;

                    GvAnswer.DataSource = dst.Tables["Tbl_Info"];
                    GvAnswer.DataBind();


                }
            }

          /*  else
            {
                string searchtxt12 = pqr;
                //  Response.Write("<script>alert('No match found, try again') </script>");
                SqlDataAdapter ad1 = new SqlDataAdapter("select  Answer from Tbl_Info Where Question LIKE '%" + searchtxt12.Replace(" ", "%' OR Question LIKE '%") + "%'", con);
                DataSet dst1 = new DataSet();
                ad1.SelectCommand.Parameters.AddWithValue("@search", searchtxt12);
                ad1.Fill(dst1, "Tbl_Info");
                if (ad1 != null)
                {
                    PnlAnswer.Visible = true;

                    GvAnswer.DataSource = dst1.Tables["Tbl_Info"];
                    GvAnswer.DataBind();

                }
            }*/
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(" + ex.Message + ") </script>");
        }
        finally
        {
            con.Close();
        }

        // only answer in textbox

        try
        {
            //  string searchtxt = TxtAskme.Text;
            string exceptions1 = "who where why when how what which whose whom with within without regard mgms mgm's colleges college's to yet so though while if even wherever rather wheather only well than through till towards under underneath until upon via behind below beneath beside off onto over considering consider per prior round between beyond but  much many mgm in case college details long far are the  it old come about against along is the of an by because means behalf other close despite down during due except follow forward futher inside include into inspite instead like near next as at please by from tell me i am is or our let know do did does give some help regarding was since across after before along anti around per";
            // string exceptions = " ";


            string[] exceptionsList1 = exceptions1.Split(' ');

            string test1 = TxtAskme.Text;
            string[] wordList1 = test1.Split(' ');

            string final1 = null;
            var result1 = wordList1.Except(exceptionsList1).ToArray();
            final1 = String.Join(" ", result1);

            string a11 = final1;
            string inputstem1 = a11;
            Porter2 stemmer = new Porter2();
            //   string outputstem = stemmer.stem(inputstem);
            // string searchtxt = outputstem;
            String pqr1 = null;

            String[] ipsStrings1 = inputstem1.Split(' ');
            foreach (var ipsString1 in ipsStrings1)
            {

                String outputstem1 = stemmer.stem(ipsString1);
                //textBoxfile.Text = outputstem;
                //  Console.WriteLine(ipsString + " => " + outputstem);
                String abc1 = null;
                abc1 = outputstem1;
                //string pqr;
                //  string pqr;
                //  pqr=null;
                pqr1 = pqr1 + " " + abc1;
                // TxtAskme.Text = abc;
            }
            //      TxtAskme.Text = pqr;
            //  string searchtxt1 = TxtAskme.Text;
            string searchtxt1 = pqr1;

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = null;
            // cmd.CommandText = "select DISTINCT Answer from Tbl_Info WHERE Question LIKE '%"+searchtxt1+"%'";
            //     cmd.CommandText = "select DISTINCT Answer from Tbl_Info Where MATCH (Question)AGAINST('%" + searchtxt1 + "%' IN NATURAL LANGUAGE MODE); ";
            cmd.CommandText = "select  Answer from Tbl_Info WHERE Question LIKE '%" + searchtxt1.Replace(" ", "%' AND Question LIKE '%") + "%' ";

           

            //   cmd.CommandText = "select DISTINCT Answer from Tbl_Info WHERE [Question] LIKE ''%' + searchtxt1.REPLACE( ' ', '%'' AND [Question] LIKE ''%') + '%''";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = (searchtxt1);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TxtAnswer.Text = (reader["Answer"].ToString());
                    Button1.Visible = true;
                                   }
            }
            if (TxtAnswer.Text == " ")
            {
                
                 cmd.CommandText = "select  Answer from Tbl_Info WHERE Question LIKE '%" + searchtxt1.Replace(" ", "%' AND Question LIKE '%") + "%' ";

           

            //   cmd.CommandText = "select DISTINCT Answer from Tbl_Info WHERE [Question] LIKE ''%' + searchtxt1.REPLACE( ' ', '%'' AND [Question] LIKE ''%') + '%''";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = (searchtxt1);
            con.Open();
             reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TxtAnswer.Text = (reader["Answer"].ToString());
                    Button1.Visible = true;
                  }
            }
                

            }
          /*  else
            {
                string searchtxt11 = pqr1;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                // Response.Write("<script>alert('No match found, try again') </script>");
                cmd.CommandText = "select  Answer from Tbl_Info WHERE Question LIKE '%" + searchtxt11.Replace(",", "%' OR Question LIKE '%") + "%'";
                //   cmd.CommandText = "select DISTINCT Answer from Tbl_Info WHERE [Question] LIKE ''%' + searchtxt1.REPLACE( ' ', '%'' AND [Question] LIKE ''%') + '%''";
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = (searchtxt11);
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxtAnswer.Text = (reader["Answer"].ToString());
                        Button1.Visible = true;
                        
                    }
                }
            }*/
            reader.Close();
            cmd.Parameters.Clear();
            con.Close();
        }

        catch (Exception ex)
        {
            Response.Write("<script>alert(" + ex.Message + ") </script>");
        }
        finally
        {
            con.Close();
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SpeechSynthesizer sp = new SpeechSynthesizer();
        //setting volume   
        sp.Volume = 100;
        //ing text box text to SpeakAsync method   
        if (TxtAnswer != null)
        {
            sp.SpeakAsync(TxtAnswer.Text);
            Response.Redirect("Inquiry", false);
        }

    }

    protected void TxtAnswer_TextChanged(object sender, EventArgs e)
    {

    }
    public void SearchCalender()
    {
        PnlAdmission.Visible = false;
        PnlCalender.Visible = true;
        PnlSyllabus.Visible = false;
        PnlFees.Visible = false;
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT Id, Name FROM Tbl_Calender";
            cmd.Connection = con;
            con.Open();
            GVCalender.DataSource = cmd.ExecuteReader();
            GVCalender.DataBind();
            con.Close();
        }
    }
    public void SearchSyllabus()
    {
        PnlAdmission.Visible = false;
        PnlCalender.Visible = false;
        PnlSyllabus.Visible = true;
        PnlFees.Visible = false;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT Id, Name FROM Tbl_Syllabus";
        cmd.Connection = con;
        con.Open();
        GvSyllabus.DataSource = cmd.ExecuteReader();
        GvSyllabus.DataBind();
        con.Close();
    }
    public void SearchAdmission()
    {
        PnlSyllabus.Visible = false;
        PnlCalender.Visible = false;
        PnlAdmission.Visible = true;
        PnlFees.Visible = false;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT Id, Name FROM Tbl_Admission";
        cmd.Connection = con;
        con.Open();
        GvAdmission.DataSource = cmd.ExecuteReader();
        GvAdmission.DataBind();
        con.Close();
    }
    public void SearchFees()
    {
        PnlAdmission.Visible = false;
        PnlCalender.Visible = false;
        PnlSyllabus.Visible = false;
        PnlFees.Visible = true;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT Id, Name FROM Tbl_Fees";
        cmd.Connection = con;
        con.Open();
        GVFees.DataSource = cmd.ExecuteReader();
        GVFees.DataBind();
        con.Close();
    }

    protected void CalenderView(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"500px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbedCalender.Text = string.Format(embed, ResolveUrl("~/FilesCalender.ashx?Id="), id);
    }
    protected void SyllabusView(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"500px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbedSyllabus.Text = string.Format(embed, ResolveUrl("~/FileSyllabus.ashx?Id="), id);
    }
    protected void AdmissionView(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"500px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbedAdmission.Text = string.Format(embed, ResolveUrl("~/FileAdmission.ashx?Id="), id);
    }
    protected void FeesView(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"500px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbedAdmission.Text = string.Format(embed, ResolveUrl("~/FileFees.ashx?Id="), id);
    }





    protected void BtnClear_Click(object sender, EventArgs e)
    {
        TxtAnswer.Text = " ";
        TxtAskme.Text = " ";
        GvAnswer.Visible = false;
        Button1.Visible = false;
     //   GVCalender.Visible = false;
       // GVCalender.Visible = false;
       // GVFees.Visible = false;
        //GvSyllabus.Visible = false;

    }
}