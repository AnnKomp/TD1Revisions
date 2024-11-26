export function initializeBabylon(canvasId) {
    document.addEventListener("DOMContentLoaded", function () {
        const canvas = document.getElementById(canvasId);
        if (!canvas) {
            console.error(`Canvas with id ${canvasId} not found`);
            return;
        }
        const engine = new BABYLON.Engine(canvas, true);

        const createScene = () => {
            const scene = new BABYLON.Scene(engine);

            const camera = new BABYLON.ArcRotateCamera(
                "camera1",
                Math.PI / 2,
                Math.PI / 4,
                10,
                new BABYLON.Vector3(0, 0, 0),
                scene
            );
            camera.attachControl(canvas, true);

            const light = new BABYLON.HemisphericLight(
                "light1",
                new BABYLON.Vector3(1, 1, 0),
                scene
            );

            const box = BABYLON.MeshBuilder.CreateBox("box", { size: 2 }, scene);

            return scene;
        };

        const scene = createScene();
        engine.runRenderLoop(() => scene.render());

        window.addEventListener("resize", () => engine.resize());
    });
}
