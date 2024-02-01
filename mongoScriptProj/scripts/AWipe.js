// Verbindung zur gewünschten Datenbank herstellen
const admin = db.getSiblingDB('admin');
const jet = db.getSiblingDB('jetstream');

 if (jet.getUser('jetUser')) {
    jet.dropUser('jetUser');
  }
  if (admin.getUser('jetAdmin')) {
    admin.dropUser('jetAdmin');
  }

 if (jet.getRole('customDMLRole')) {
    jet.dropRole('customDMLRole');
  }

 
jet.dropDatabase();
