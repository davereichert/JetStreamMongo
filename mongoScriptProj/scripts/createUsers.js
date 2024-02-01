const jet = db.getSiblingDB('jetstream');

jet.createRole({
    role: "customDMLRole",
    privileges: [
        { resource: { db: "jetstream", collection: "" }, actions: ["find", "insert", "update", "remove"] },
        // Sie können zusätzliche Ressourcen und Aktionen hier hinzufügen
    ],
    roles: []
});

jet.createUser({
    user: "jetUser",
    pwd: "jetUserPwD",
    roles: [
        { role: "customDMLRole", db: "jetstream" }
    ]
});

db.getSiblingDB('admin').createUser({
    user: "jetAdmin",
    pwd: "jetAdminPwD",
    roles: [
        "root"
    ]
});
