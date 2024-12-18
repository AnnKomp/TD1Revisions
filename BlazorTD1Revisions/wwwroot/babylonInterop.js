﻿window.initializeBabylon = function (canvasId) {
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
        const wallLong = 7.36;
        const wallCourt = 5.75;

        // Créer les murs
        for (let i = 1; i <= 4; i++) {
            const [rotationY, positionX, positionZ, widthMur, color] = PositionMur(wallCourt, wallLong, i);

            const wall = BABYLON.MeshBuilder.CreateBox(`wall${i}`, {
                height: wallHeight,
                width: widthMur,
                depth: wallThickness,
                faceColors: [
                    color,
                    color,
                    color,
                    color,
                    color,
                    color,
                    color
                ]
            }, scene);

            // Appliquer la rotation et la position
            wall.rotation.y = rotationY;
            wall.position.x = positionX;
            wall.position.z = positionZ;
        }
        
        // Sol
        const floor = BABYLON.MeshBuilder.CreateBox("floor", {
            height: 0.01,
            width: wallLong,
            depth: wallCourt
        }, scene);
        floor.position.y = -1.35;


        // porte
        const porte = BABYLON.MeshBuilder.CreateBox("porte", {
            height: 2.05,
            width: 0.93,
            depth: wallThickness + 0.2
        }, scene);
        porte.rotation.y = -Math.PI / 2;
        porte.position.x = wallLong / 2;
        porte.position.y = wallHeight / 2 - 0.67 - (2.05 / 2)
        porte.position.z = wallCourt / 2 - 0.55 - (0.93 / 2)

        // exemple MILIEU MUR
        const point = BABYLON.MeshBuilder.CreateBox("point", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1) //rouge
            ]
        }, scene);
        point.rotation.y = 0;
        point.position.x = 0;
        point.position.y = 0;
        point.position.z = - wallCourt / 2;


        // exemple MILIEU MUR NEG
        const pointNeg = BABYLON.MeshBuilder.CreateBox("pointNeg", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1) //rouge
            ]
        }, scene);
        pointNeg.rotation.y = 0;
        pointNeg.position.x = - wallLong / 2;
        pointNeg.position.y = 0;
        pointNeg.position.z = - wallCourt / 2;

        // cap1
        const cap1 = BABYLON.MeshBuilder.CreateBox("cap1", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1) //noir
            ]
        }, scene);
        cap1.rotation.y = 0;
        cap1.position.x = + wallLong / 2 - 3.16 - 0.1;
        cap1.position.y = + wallHeight / 2 - 0.70 - 0.1;
        cap1.position.z = - wallCourt / 2;

        // cap2
        const cap2 = BABYLON.MeshBuilder.CreateBox("cap2", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0) // jaune
            ]
        }, scene);
        cap2.rotation.y = 0;
        cap2.position.x = + wallLong / 2 - 6.62 - 0.1;
        cap2.position.y = + wallHeight / 2 - 1.56 - 0.1;
        cap2.position.z = - wallCourt / 2;


        // cap3
        const cap3 = BABYLON.MeshBuilder.CreateBox("cap3", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1),
                new BABYLON.Color4(0, 0, 0, 1) //noir
            ]
        }, scene);
        cap3.rotation.y = 0;
        cap3.position.x = - wallLong / 2 + 1.78 + 0.1;
        cap3.position.y = + wallHeight / 2 - 0.98 - 0.1;
        cap3.position.z = wallCourt / 2;

        // cap4
        const cap4 = BABYLON.MeshBuilder.CreateBox("cap4", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0),
                new BABYLON.Color4(1, 1, 0, 0) // jaune
            ]
        }, scene);
        cap4.rotation.y = 0;
        cap4.position.x = - wallLong / 2 + 5.85 + 0.1;
        cap4.position.y = + wallHeight / 2 - 1.61 - 0.1;
        cap4.position.z = wallCourt / 2;


        // fenetre 1
        const fen1 = BABYLON.MeshBuilder.CreateBox("fen1", {
            height: 1.65,
            width: 1.00,
            depth: wallThickness + 0.1
        }, scene);
        fen1.rotation.y = -Math.PI / 2;
        fen1.position.x = - wallLong / 2;
        fen1.position.y = wallHeight / 2 - 0.03 - (1.65 / 2)
        fen1.position.z = - wallCourt / 2 + 0.06 + (1.00 / 2)

        // fenetre 2
        const fen2 = BABYLON.MeshBuilder.CreateBox("fen2", {
            height: 1.65,
            width: 1.00,
            depth: wallThickness + 0.1
        }, scene);
        fen2.rotation.y = -Math.PI / 2;
        fen2.position.x = - wallLong / 2;
        fen2.position.y = wallHeight / 2 - 0.03 - (1.65 / 2)
        fen2.position.z = - wallCourt / 2 + 3.45 + (1.00 / 2)

        // vitre 1
        const vit1 = BABYLON.MeshBuilder.CreateBox("vit1", {
            height: 1.61,
            width: 0.89,
            depth: wallThickness + 0.1
        }, scene);
        vit1.rotation.y = -Math.PI / 2;
        vit1.position.x = - wallLong / 2;
        vit1.position.y = wallHeight / 2 - 0.06 - (1.61 / 2)
        vit1.position.z = - wallCourt / 2 + 1.25 + (0.89 / 2)

        // vitre 2
        const vit2 = BABYLON.MeshBuilder.CreateBox("vit2", {
            height: 1.61,
            width: 0.89,
            depth: wallThickness + 0.1
        }, scene);
        vit2.rotation.y = -Math.PI / 2;
        vit2.position.x = - wallLong / 2;
        vit2.position.y = wallHeight / 2 - 0.06 - (1.61 / 2)
        vit2.position.z = - wallCourt / 2 + 2.37 + (0.89 / 2)

        // vitre 3
        const vit3 = BABYLON.MeshBuilder.CreateBox("vit3", {
            height: 1.61,
            width: 0.89,
            depth: wallThickness + 0.1
        }, scene);
        vit3.rotation.y = -Math.PI / 2;
        vit3.position.x = - wallLong / 2;
        vit3.position.y = wallHeight / 2 - 0.06 - (1.61 / 2)
        vit3.position.z = - wallCourt / 2 + 4.82 + (0.89 / 2)


        // radiateur 1
        const rad1 = BABYLON.MeshBuilder.CreateBox("rad1", {
            height: 0.80,
            width: 1.60,
            depth: wallThickness + 0.1
        }, scene);
        rad1.rotation.y = -Math.PI / 2;
        rad1.position.x = - wallLong / 2;
        rad1.position.y = - 1.28 + (0.80 / 2)
        rad1.position.z = - wallCourt / 2 + 0.34 + (1.60 / 2)

        // radiateur 2
        const rad2 = BABYLON.MeshBuilder.CreateBox("rad2", {
            height: 0.80,
            width: 1.60,
            depth: wallThickness + 0.1
        }, scene);
        rad2.rotation.y = -Math.PI / 2;
        rad2.position.x = - wallLong / 2;
        rad2.position.y = - 1.28 + (0.80 / 2)
        rad2.position.z = - wallCourt / 2 + 2.56 + (1.60 / 2)

        // exemple POINT DEPART
        const depart = BABYLON.MeshBuilder.CreateBox("depart", {
            height: 0.2,
            width: 0.2,
            depth: 0.2,
            faceColors: [
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1),
                new BABYLON.Color4(1, 0, 0, 1) //rouge
            ]
        }, scene);
        depart.position.x = 0;
        depart.position.y = 0;
        depart.position.z = 0;

        return scene;
    };

    const scene = createScene();
    engine.runRenderLoop(() => scene.render());
    window.addEventListener("resize", () => engine.resize());
};

function PositionMur(salleLargeur, salleLongueur, typeMur) {
    let widthMur = 0;
    let rotationY = 0;
    let positionX = 0;
    let positionZ = 0;
    let color;

    // Calcul des propriétés du mur en fonction du type (1, 2, 3, 4)
    if (typeMur === 1) {
        widthMur = salleLargeur;
        rotationY = -Math.PI / 2;
        positionX = salleLongueur / 2;
        positionZ = 0;
        color = new BABYLON.Color3.FromInts(153, 255, 255);
    } else if (typeMur === 2) {
        widthMur = salleLongueur;
        rotationY = 0;
        positionX = 0;
        positionZ = salleLargeur / 2;
        color = new BABYLON.Color3.FromInts(153, 255, 153);
    } else if (typeMur === 3) {
        widthMur = salleLargeur;
        rotationY = Math.PI / 2;
        positionX = -salleLongueur / 2;
        positionZ = 0;
        color = new BABYLON.Color3.FromInts(153, 153, 255);
    } else if (typeMur === 4) {
        widthMur = salleLongueur;
        rotationY = Math.PI;
        positionX = 0;
        positionZ = -salleLargeur / 2;
        color = new BABYLON.Color3.FromInts(255, 153, 204);
    }

    // Retourner les paramètres du mur
    return [rotationY, positionX, positionZ, widthMur, color];
}
