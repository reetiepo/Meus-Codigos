$(function () {

            var canvas = $("#target");
            canvas.css("visibility", "visible");
            var context = canvas.get(0).getContext("2d");
            var canvasWidth = canvas.width();
            var canvasHeight = canvas.height();
            var entities = [];

            $(window).resize(resizeCanvas);

            function resizeCanvas() {
                canvas.attr("width", $(window).get(0).innerWidth);
                canvas.attr("height", $(window).get(0).innerHeight);
                canvasWidth = canvas.width();
                canvasHeight = canvas.height();
            };

            resizeCanvas();

            // ---------------------------------------------------------------------
            var MatrixUtils = {
                identity: function () {
                    return new Matrix([
                    [1, 0, 0, 0],
                    [0, 1, 0, 0],
                    [0, 0, 1, 0],
                    [0, 0, 0, 1]
                ]);
                },

                rotationZ: function (q) {
                    return new Matrix([
                    [Math.cos(q), Math.sin(q), 0, 0],
                    [-Math.sin(q), Math.cos(q), 0, 0],
                    [0, 0, 1, 0],
                    [0, 0, 0, 1]
                ]);
                },

                rotationX: function (q) {
                    return new Matrix([
                    [1, 0, 0, 0],
                    [0, Math.cos(q), Math.sin(q), 0],
                    [0, -Math.sin(q), Math.cos(q), 0],
                    [0, 0, 0, 1]
                ]);
                },

                rotationY: function (q) {
                    return new Matrix([
                    [Math.cos(q), 0, -Math.sin(q), 0],
                    [0, 1, 0, 0],
                    [Math.sin(q), 0, Math.cos(q), 0],
                    [0, 0, 0, 1]
                ]);
                },

                translation: function (dx, dy, dz) {
                    return new Matrix([
                        [1, 0, 0, dx],
                        [0, 1, 0, dy],
                        [0, 0, 1, dz],
                        [0, 0, 0, 1]
                    ]);
                },

                scale: function (sx, sy, sz) {
                    return new Matrix([
                        [sx, 0, 0, 0],
                        [0, sx, 0, 0],
                        [0, 0, sz, 0],
                        [0, 0, 0, 1]
                    ]);
                }
            };

            function Matrix(cells) {
                this.cells = cells;

                this.mult = function (m) {
                    var result = [];
                    for (var i = 0; i < 4; i++) {
                        result[i] = [];
                        for (var j = 0; j < 4; j++) {
                            result[i][j] = this.cells[i][0] * m.cells[0][j] +
                                this.cells[i][1] * m.cells[1][j] +
                                this.cells[i][2] * m.cells[2][j] +
                                this.cells[i][3] * m.cells[3][j];
                        }
                    }
                    return new Matrix(result)
                }
            }

            // ---------------------------------------------------------------------
            function Vector3D(x, y, z) {
                this.x = x;
                this.y = y;
                this.z = z;

                this.perspective = function (viewWidth, viewHeight, fov, viewDistance) {
                    var factor, x, y
                    factor = fov / (viewDistance + this.z)
                    x = this.x * factor + viewWidth / 2
                    y = this.y * factor + viewHeight / 2
                    return new Vector3D(x, y, this.z)
                };

                this.mult = function (m) {
                    var nx, ny, nz;
                    nx = m.cells[0][0] * this.x +
                     m.cells[0][1] * this.y +
                     m.cells[0][2] * this.z +
                     m.cells[0][3];

                    ny = m.cells[1][0] * this.x +
                     m.cells[1][1] * this.y +
                     m.cells[1][2] * this.z +
                     m.cells[1][3];

                    nz = m.cells[2][0] * this.x +
                     m.cells[2][1] * this.y +
                     m.cells[2][2] * this.z +
                     m.cells[2][3];

                    return new Vector3D(nx, ny, nz);
                };

                this.normalize = function () {
                    var d = Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
                    return new Vector3D(this.x / d, this.y / d, this.z / d);
                };

                this.cross = function (another) {
                    x = this.y * another.z - this.z * another.y;
                    y = this.z * another.x - this.x * another.z;
                    z = this.x * another.y - this.y * another.x;
                    return new Vector3D(x, y, z);
                }

                this.dot = function (another) {
                    return this.X * another.X + this.Y * another.Y + this.Z * another.Z;
                }
            }

            // ---------------------------------------------------------------------
            function Cube(scaleMatrix, rotationMatrix, translationMatrix) {
                var vertices = [
                    new Vector3D(-1, 1, -1),
                    new Vector3D(1, 1, -1),
                    new Vector3D(1, -1, -1),
                    new Vector3D(-1, -1, -1),
                    new Vector3D(-1, 1, 1),
                    new Vector3D(1, 1, 1),
                    new Vector3D(1, -1, 1),
                    new Vector3D(-1, -1, 1)
                ];

                var faces = [
                    [0, 1, 2, 3],
                    [1, 5, 6, 2],
                    [5, 4, 7, 6],
                    [4, 0, 3, 7],
                    [0, 4, 5, 1],
                    [3, 2, 6, 7]
                ];

                this.scaleMatrix = scaleMatrix;
                this.rotationMatrix = rotationMatrix;
                this.translationMatrix = translationMatrix;


                this.draw = function (context, w, h) {
                    var t = new Array();
                    for (var i = 0; i < 8; i++) {
                        var v = vertices[i];
                        var r = v
                            .mult(this.scaleMatrix)
                            .mult(this.rotationMatrix)
                            .mult(this.translationMatrix);
                 
                        t.push(r.perspective(canvasWidth, canvasHeight,
                                Math.min(canvasWidth, canvasHeight) * 0.9,
                                3.5)
                                );
                    }
                    context.strokeStyle = "rgb(255,255,255)";
                    var colors = "rgb(0, 0, 0)";
                 
                    for (var i = 0; i < faces.length; i++) {
                        var f = faces[i];
                 
                        // calculando o vetor normal
                        v1 = new Vector3D(
                            t[f[1]].x - t[f[0]].x,
                            t[f[1]].y - t[f[0]].y,
                            t[f[1]].z - t[f[0]].z);
                 
                        v2 = new Vector3D(
                            t[f[3]].x - t[f[0]].x,
                            t[f[3]].y - t[f[0]].y,
                            t[f[3]].z - t[f[0]].z);
                 
                        vcross = v1.cross(v2);
                 
                        if (vcross.z < 0) { // face oculta
                            context.fillStyle = colors;
                            context.beginPath();
                            context.moveTo(t[f[0]].x, t[f[0]].y);
                            context.lineTo(t[f[1]].x, t[f[1]].y);
                            context.lineTo(t[f[2]].x, t[f[2]].y);
                            context.lineTo(t[f[3]].x, t[f[3]].y);
                            context.closePath();
                            context.fill();  
                            context.stroke();                     
                        }
                    }
                }
            }

            // ---------------------------------------------------------------------
            function DTR(x) {
                return x * Math.PI / 180;
            }

            function loadContent() {

                entities.push(new Cube(
                    MatrixUtils.scale(0.5, 0.5, 0.5),
                    MatrixUtils.identity(),
                    MatrixUtils.translation(0, 0, 0)
                    ));

                animate(0, 0);
            }
            loadContent();

            function animate(x, y) {
                update(x, y);
                draw();
            }

            function update(x, y) {
                entities[0].rotationMatrix = entities[0].rotationMatrix
                    .mult(MatrixUtils.rotationX(DTR(x)))
                    .mult(MatrixUtils.rotationZ(DTR(y)));
            }

            function draw() {
                context.clearRect(0, 0, canvasWidth, canvasHeight);
                entities[0].draw(context, canvasWidth, canvasHeight);
            }

            $('body').keydown(function(evt) {
                var i;
                var xAngle = 0, yAngle = 0;
                switch(evt.keyCode) {
                    case 37: // left
                        yAngle = 9;
                        break;

                    case 38: // up
                        xAngle = -9;
                        break;

                    case 39: // right
                        yAngle = -9;
                        break;

                    case 40: // down
                        xAngle = 9;
                        break;
                };
                var setTime;
                for (i = 0; i < 9; i++){
                    setTime = setInterval(animate(xAngle, yAngle), 1000);
                }
                clearInterval(setTime)
            });
        });