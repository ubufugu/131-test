using System;
using Gtk;
using System.IO;
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();//builds main window
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButtonClearClicked (object sender, System.EventArgs e)
	{
		textview1.Buffer.Text="";//clears the buffer displayed by the TextView
	}
	
	protected virtual void OnButtonUpperClicked (object sender, System.EventArgs e)
    {
        //code executed when the Upper Case button is clicked
        textview1.Buffer.Text=textview1.Buffer.Text.ToUpper();
    }

    protected virtual void OnButtonLowerClicked (object sender, System.EventArgs e)
    {
        //code executed when the Lower Case button is clicked
        textview1.Buffer.Text=textview1.Buffer.Text.ToLower();
    }
    

    protected virtual void OnButton4Clicked (object sender, System.EventArgs e)
    {
        //code executed when the Copy button is clicked
        StreamWriter sw=new StreamWriter("Test.txt");
        sw.Write(textview1.Buffer.Text); //Write textview1 text to file
        textview1.Buffer.Text="Saved to file !"; //Notify user
        sw.Close(); 
    }

	protected void OnClearallActionActivated (object sender, System.EventArgs e)
	{
		textview1.Buffer.Text="";//clears the buffer displayed by the TextView
	}

	protected void OnEXitActivated (object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	protected void OnOpenActivated (object sender, System.EventArgs e)
	{
     // Reset the logTreeView and change the window back to original size
     int width, height;
     this.GetDefaultSize( out width, out height );
     this.Resize( width, height );
     
     logTextView.Buffer.Text = "";
     
     // Create and display a fileChooserDialog
     FileChooserDialog chooser = new FileChooserDialog(
        "Please select a logfile to view ...",
        this,
        FileChooserAction.Open,
        "Cancel", ResponseType.Cancel,
        "Open", ResponseType.Accept );
     
     if( chooser.Run() == ( int )ResponseType.Accept )
     {
        // Open the file for reading.
        System.IO.StreamReader file =
        System.IO.File.OpenText( chooser.Filename );
        
        // Copy the contents into the logTextView
        logTextView.Buffer.Text = file.ReadToEnd();
        
        // Set the MainWindow Title to the filename.
        this.Title = "Jon's Log Viewer -- " + chooser.Filename.ToString();
        
        // Make the MainWindow bigger to accomodate the text in the logTextView
        //this.Resize( 640, 480 );
        
        // Close the file so as to not leave a mess.
        file.Close();
     } // end if
     chooser.Destroy();
	}

	protected void OnCLoseActivated (object sender, System.EventArgs e)
	{
	// Reset the logTreeView and change the window back to original size
    int width, height;
    this.GetDefaultSize( out width, out height );
    this.Resize( width, height );
    
    logTextView.Buffer.Text = "";
    
    // Change the MainWindow Title back to the default.
    this.Title = "Jon's Log Viewer";;
	}

	protected void OnHelpActivated (object sender, System.EventArgs e)
	{
	// Create a new About dialog
    AboutDialog about = new AboutDialog();
    
    // Change the Dialog's properties to the appropriate values.
    about.ProgramName = "Jon's Log Viewer";
    about.Version = "1.0.0";
    
    // Show the Dialog and pass it control
    about.Run();
    
    // Destroy the dialog
    about.Destroy();
	}
}
