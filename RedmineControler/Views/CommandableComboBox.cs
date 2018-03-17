using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RedmineControler
{
    class CommandableComboBox : ComboBox, ICommandSource
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof( ICommand ),
            typeof( CommandableComboBox ),
            new PropertyMetadata( null,
            new PropertyChangedCallback( CommandChanged ) ) );

        public int ID { get; set; }
        
        public ICommand Command
        {
            get { return ( ICommand )GetValue( CommandProperty ); }
            set { SetValue( CommandProperty, value ); }
        }

        public object CommandParameter
        {
            get { return new object(); }
        }

        public IInputElement CommandTarget
        {
            get { return this; }
        }

        public CommandableComboBox() : base()
        {
        }

        private static void CommandChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
        }

        protected override void OnSelectionChanged( SelectionChangedEventArgs e )
        {
            base.OnSelectionChanged( e );
            if( this.Command != null ) {
                if( this.Command is RoutedCommand command ) {
                    command.Execute( this.CommandParameter, this.CommandTarget );
                }
                else {
                    this.Command.Execute( this.CommandParameter );
                }
            }
        }
    }
}
