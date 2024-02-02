# Restaurant App
#### by Ravin Fisher, Brianca Knight & Kim Robinson

### Prompt
Create a website where users can add their favorite restaurants based on the type of cuisine they offer.

    Add a Cuisine class. Build out all CRUD functionality (Create, Read, Update, Delete) for this class. Remember that "Read" means to view a particular cuisine and to list out all of the cuisines.

    Add a Restaurant class. Build out all CRUD functionality for this class.

    Add properties other than name to your Restaurant class so that you can display descriptive information about the restaurants.

    Make the connection between a cuisine and a restaurant in the database. A cuisine can have many restaurants, but a restaurant can only be attached to one cuisine.

    Allow a user to search for all of a cuisine's restaurants.
* Further Exploration

_If you have time, go ahead and tackle the next few features._

  Now your application allows for users to review restaurants. Build out a Review class and make the relationship in the database so that a restaurant has many reviews. Pretend that the users who are reviewing the website are different from the user who added the restaurant.

  Display all of the reviews at the bottom of the restaurant's page.

### Stretch Goals:
* Search box only works on /Restaurants page
* Style search box to match other buttons
* Style add forms
* Want add comment to be attached automatically to the restaurant
* Update Restaurant property "Type" to "Service Type" to refect hours (i.e. Breakfast, Brunch, Lunch, Dinner)
---------------------
* Using the .sql file in this repo, import to your MySqlWorkbench and follow steps below:

  # Importing .sql file to your database:
    In the Navigator > Administration window, select Data Import/Restore.

    In Import Options select Import from Self-Contained File.

    Navigate to the file we just created.

    Under Default Schema to be Imported To, select the New button.
        
    Enter the name of your database with _test appended to the end.
    In this case to_do_list_with_mysqlconnector_test.
    Click Ok.

    Navigate to the tab called Import Progress and click Start Import at the bottom right corner of the window.

After you are finished with the above steps, reopen the Navigator > Schemas tab. Right click and select Refresh All. Our new test database will appear.