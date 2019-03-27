const obj = {
    initialise: () => {
        obj.Fullname = obj.values.name + " " + obj.values.surname
    },
    values: {
        name: "George",
        surname: "Grech"
    }
};


obj.initialise();