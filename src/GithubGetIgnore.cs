using System;
using System.Collections.Generic;
using System.Text;
using GetIgnore.Github;

namespace GetIgnore
{
    public class GHGetIgnore
    {
        GithubAPI _gh;

        public GHGetIgnore(Options flags = Options.None){
            _gh = new GithubAPI();
        }

        ///<Summary>
        /// Gets the gitignore for each of the specified environments. Skips invalid entries.
        ///</Summary>
        public string Get(IEnumerable<String> ignoreFiles)
        {
            StringBuilder gitignore = new StringBuilder();
            foreach(string ignore in ignoreFiles)
            {
                try
                {
                    gitignore.Append(_gh.download(ignore) + Environment.NewLine);
                }
                catch( Exception ex ) 
                {
                    Console.WriteLine("Error: Could not download the specified .gitignore: {0}", ignore);
                    Console.WriteLine(ex.Message);
                }
            }
            return gitignore.ToString();
        }

        // TODO: Implement lol
        public string Search(string[] ignoreFiles)
        {
            string gitignore = "";
            foreach(string ignore in ignoreFiles)
            {
                try
                {
                    gitignore += _gh.search(ignore);
                }
                catch( Exception ex )
                {
                    Console.WriteLine("Error: Could not complete search: {0}", ignore);
                    Console.WriteLine(ex.Message);
                }
            }
            return gitignore;
        }
    }
}