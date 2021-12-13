using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesCompany.Agents
{
    /// <summary>
    /// Логика взаимодействия для AgentsList.xaml
    /// </summary>
    public partial class AgentsList : Page
    {
        public AgentsList()
        {
            InitializeComponent();
            AgentsListView.ItemsSource = SalesCompanyEntities.GetContext().VW_AgentDetails.ToList();
            TypeAgents.ItemsSource = SalesCompanyEntities.GetContext().type_agents.ToList();
        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string query = textBox.Text;

            
            AgentsListView.Items.Filter += new Predicate<object>(item =>
            {
                VW_AgentDetails agent = item as VW_AgentDetails;

                return agent.NameAgent.Contains(query) && agent.Name.Contains((TypeAgents.SelectedItem as type_agents).Name);

            });
        }

        private void TypeAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox textBox = sender as ComboBox;

            type_agents query = textBox.SelectedItem as type_agents;


            AgentsListView.Items.Filter += new Predicate<object>(item =>
            {
                VW_AgentDetails agent = item as VW_AgentDetails;

                return agent.Name.Contains(query.Name) && agent.Name.Contains(SearchField.Text);

            });
        }
    }
}
