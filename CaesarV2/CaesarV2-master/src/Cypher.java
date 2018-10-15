import java.util.*;

public class Cypher
    {
        public static void main(String[] args)
            {
                Scanner scan = new Scanner(System.in);
                String op;  //option for what the user wants to do
                
                do{
                    System.out.println("E - encrypt\nD - decrypt\nX - exit");
                    op = scan.nextLine();
        
                    System.out.print("Enter phrase: ");
                    String phrase = scan.nextLine();
                    System.out.println();
        
                        if (op.equalsIgnoreCase("e"))     //user wants to encrypt
                            {
                                System.out.println("Enter shift: ");
                                int shift = scan.nextInt();
                                scan.nextLine();
                
                                System.out.println(encrypt(phrase, shift));
                            }
                            
                        else if (op.equalsIgnoreCase("d"))    //user wants to decrypt
                            {
                                System.out.println(decrypt(phrase));
                            }
                    
                    }while(!op.equalsIgnoreCase("X"));
            }
        
        private static String decrypt(String message)
            {
                int bestShift = 0; //Holds the shift key that gives the least variation from the expected distribution of letters
                
                for(int shift = 0; shift<=26; shift++) //finds shift key
                    {
                        if (calcDifference(message, shift) < calcDifference(message, bestShift))
                            bestShift = shift;
                    }
                
                return encrypt(message, 26 - bestShift); //returns the decrypted message
            }
        
        private static double calcDifference(String message, int shift)
            {
                //arrays are parallel
                final char[] Alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
                final double[] LetterFreq= {8.167, 1.492, 2.782, 4.253, 12.702, 2.228, 2.015, 6.094, 6.966, 0.153, 0.772, 4.4025, 2.406, 6.749, 7.507, 1.929, 0.095, 5.5987, 6.327, 9.056, 2.758, 0.978, 2.36, 0.150, 1.974, 0.074};
                //holds the average frequency of each letter in the english alphabet for every 100 characters
                
                double[] localFreq = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 , 0, 0, 0, 0};
                double difference = 0;
    
                //counts how many times each character appears in phrase w/ given shift
                for(char c: message.toLowerCase().toCharArray())
                    for (int alpha = 0; alpha < Alphabet.length; alpha++)
                            if(c == (Alphabet[(alpha+shift)%26]))
                                localFreq[alpha]++;
                
                //calculates the percentage of occurrence in message for each letter
                for (int f = 0; f < localFreq.length; f++)
                        localFreq[f] *= (100 / message.length());
    
                //calculates the average difference for given shift
                for(int d = 0; d < localFreq.length; d++)
                    difference += (Math.abs(LetterFreq[d] - localFreq[d]));
                
                System.out.println("\nShift: "+shift +"\nDifference: " +difference);
                
                return difference;
            }
    
        private static String encrypt(String message, int shift) //Needs to be changed to use alphabet array to
            {
                String translation = ""; //encrypted message
                
                for(char c: message.toCharArray())
                    {
                        if(Character.isLetter(c)) //translated letters
                            {
                                if(Character.isUpperCase(c))
                                    translation += (char)( (((int)(c) - 65 + shift)%26) + 65 ); // shifted place in alphabet + start of case
                                else                                                            //((place in alphabet) % 26) + start of case
                                    translation += (char)( (((int)(c) - 97 + shift)%26) + 97 ); //((char - start of case + shift) % 26) + start of case
                            }
                        else //adds symbols
                            translation += c;
                    }
                
                return translation;
            }
    }
