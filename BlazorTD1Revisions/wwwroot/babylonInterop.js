window.initializeBabylon = function (canvasId) {
    const canvas = document.getElementById(canvasId);
    const engine = new BABYLON.Engine(canvas, true);

    const createScene = () => {
        const scene = new BABYLON.Scene(engine);

        // Caméra
        const camera = new BABYLON.ArcRotateCamera(
            "camera1",
            Math.PI / 2,
            Math.PI / 4,
            10,
            new BABYLON.Vector3(0, 0, 0),
            scene
        );
        camera.attachControl(canvas, true);

        // Lumière
        const light = new BABYLON.HemisphericLight(
            "light1",
            new BABYLON.Vector3(1, 1, 0),
            scene
        );

        //WALLS
        const wallHeight = 2.7; // 270 cm (hauteur des murs)
        const wallThickness = 0.1; // 10 cm (épaisseur des murs)

        // Mur 1 (736 cm de long)
        const wall1 = BABYLON.MeshBuilder.CreateBox("wall1", {
            height: wallHeight,
            width: 7.36, // 736 cm
            depth: wallThickness,
            faceColors: [
                new BABYLON.Color4(1,0,1,1) //violet
            ]
        }, scene);
        wall1.position.x = 0;
        wall1.position.z = -5.35/2// Positionner le mur 1 à moitié de la longueur

        // Mur 2 (535 cm de long)
        const wall2 = BABYLON.MeshBuilder.CreateBox("wall2", {
            height: wallHeight,
            width: 5.35, // 535 cm
            depth: wallThickness,
            faceColors: [
                new BABYLON.Color4(0, 1, 0, 1) //vert
            ]
        }, scene);
        wall2.rotation.y = - Math.PI / 2;
        wall2.position.x = 7.36 / 2
        wall2.position.z = 0; // Positionner le mur 2 à moitié de la largeur

        // Mur 3 (736 cm de long, rotation de 90° pour l'orientation)
        const wall3 = BABYLON.MeshBuilder.CreateBox("wall3", {
            height: wallHeight,
            width: 7.36, // 736 cm
            depth: wallThickness,
            faceColors: [
                new BABYLON.Color4(0, 0, 1, 1) // bleu
            ]
        }, scene);
        wall3.rotation.y = Math.PI; // Rotation de 90° pour aligner avec le mur précédent
        wall3.position.x = 0; // Positionner le mur 3 de l'autre côté
        wall3.position.z = 5.35 / 2;

        // Mur 4 (535 cm de long, rotation de 90° pour l'orientation)
        const wall4 = BABYLON.MeshBuilder.CreateBox("wall4", {
            height: wallHeight,
            width: 5.35, // 535 cm
            depth: wallThickness,
            faceColors: [
                new BABYLON.Color4(1, 1, 0, 1) //jaune
            ]
        }, scene);
        wall4.rotation.y = Math.PI / 2; // Rotation de 90° pour aligner avec le mur précédent
        wall4.position.x = -7.36/2
        wall4.position.z = 0; // Positionner le mur 4 de l'autre côté

        const floor = BABYLON.MeshBuilder.CreateBox("floor", {
            height: 0.01, // épaisseur du sol
            width: 7.36, // même largeur que les murs longs
            depth: 5.35 // même profondeur que les murs courts
        }, scene);
        floor.position.y = -1.35; // Positionner le sol sous les murs

        //// Cube
        //const box = BABYLON.MeshBuilder.CreateBox("box",
        //    {
        //        size: 2
        //    },
        //    scene);

        return scene;
    };

    const scene = createScene();
    engine.runRenderLoop(() => scene.render());
    window.addEventListener("resize", () => engine.resize());
};
