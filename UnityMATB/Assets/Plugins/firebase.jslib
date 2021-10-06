var LibraryMyPlugin = {

		$MyDb: {
		   db: "",
	   },
	   
		initFirebase: function () {
			firebase.initializeApp({
			apiKey: "AIzaSyAZkRs35cZaznaQ8T-I7Z1imreuxDo-LzQ",
			authDomain: "matb2-602f7.firebaseapp.com",
			projectId: "matb2-602f7",
		  });
			MyDb.db = firebase.firestore();
		  },

  addToDatabase: function(jsonString){
	  const convertedString = Pointer_stringify(jsonString);
	  const jsonParsed = JSON.parse(convertedString);

       MyDb.db.collection("Data").add(jsonParsed)
      .then(function() {
          console.log("success");
      })
      .catch(function (error){
          console.error("Error: ", error);
      });
  },
};

autoAddDeps(LibraryMyPlugin, '$MyDb');
mergeInto(LibraryManager.library, LibraryMyPlugin);
