// mitarbeiterSetup.js
const jet = db.getSiblingDB('jetstream');

jet.createCollection('Mitarbeiter', {
    validator: {
       $jsonSchema: {
           bsonType: "object",
           required: [ "Name","Benutzername","Passwort", "Email","Telefonnummer","Rolle" ],
           properties: {
                _id: {
                    bsonType: "objectId",
                    description: "muss ein gültiger ObjectId sein"
                },
                Name: {
                   bsonType: "string",
                   description: "muss vorhanden und eine Zeichenkette sein"
               },
               Benutzername: {
                bsonType: "string",
                description: "muss vorhanden und eine Zeichenkette sein"
                },
                Passwort: {
                    bsonType: "string",
                    description: "muss vorhanden und eine Zeichenkette sein"
                    },
               Email: {
                   bsonType: "string",
                   pattern: "^.+@.+\..+$",
                   description: "muss eine gültige E-Mail-Adresse sein"
               },
               Telefonnummer: {
                   bsonType: "string",
                   description: "kann nur eine Zeichenkette sein"
               },
               
               Rolle: {
                bsonType: "string",
                description: "kann nur eine Zeichenkette sein"
                }
            
           }
       }
    }
});

jet.Mitarbeiter.createIndex({ Benutzername: 1 }, { unique: true });

