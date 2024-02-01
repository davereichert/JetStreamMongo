// serviceAuftragSetup.js
const jet = db.getSiblingDB('jetstream');

jet.createCollection('ServiceAuftrag', {
    validator: {
       $jsonSchema: {
           bsonType: "object",
           required: [ "Name", "Email", "Phone", "Priority", "Service", "CreateDate", "PickupDate" ],
           properties: {
               _id: {
                   bsonType: "objectId",
                   description: "muss ein gültiger ObjectId sein"
               },
               Name: {
                   bsonType: "string",
                   description: "muss vorhanden und eine Zeichenkette sein"
               },
               Email: {
                   bsonType: "string",
                   pattern: "^.+@.+\..+$",
                   description: "muss eine gültige E-Mail-Adresse sein"
               },
               Phone: {
                   bsonType: "string",
                   description: "muss vorhanden und eine Zeichenkette sein"
               },
               Priority: {
                   bsonType: "string",
                   description: "muss vorhanden und eine Zeichenkette sein"
               },
               Service: {
                   bsonType: "string",
                   description: "muss vorhanden und eine Zeichenkette sein"
               },
               CreateDate: {
                   bsonType: "date",
                   description: "muss vorhanden und ein Datum sein"
               },
               PickupDate: {
                   bsonType: "date",
                   description: "muss vorhanden und ein Datum sein"
               }
           }
       }
    }
});

jet.ServiceAuftrag.createIndex({ Service: 1 }, { unique: false });


