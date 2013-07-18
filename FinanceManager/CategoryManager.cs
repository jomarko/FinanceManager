using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager
{
    class CategoryManager
    {
        private List<Category> incomes;
        private List<Category> outgoes;

        public CategoryManager()
        {
            String[] inNames = {"Mzda", "Výhra", "Dar", "Predaj", "Renta", "Úroky", "Štipendium", "Iné"};
            String[] outNames = {"MHD", "Vlak/Autobus", "Dovolenka", "Voda/Plyn/Elektrina", "Strava", "Oblečenie", "Domácnosť", "Kúpa", "Iné" };

            incomes = new List<Category>();
            outgoes = new List<Category>();

            for (int i = 0; i < inNames.Length; i++)
            {
                incomes.Add(new Category());
                incomes[i].Name = inNames[i];
            }

            for (int i = 0; i < outNames.Length; i++)
            {
                outgoes.Add(new Category());
                outgoes[i].Name = outNames[i];
            }
        }

        public List<Category> GetAllIncomes()
        {
            return new List<Category>(incomes);
        }

        public List<Category> GetAllOutgoes()
        {
            return new List<Category>(outgoes);
        }
    }
}
