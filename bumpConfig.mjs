import config from './config.json' with {type: 'json'};
import pkg from './package.json' with {type: 'json'};
import fs from 'fs'
import cp from 'child_process'
import { fileURLToPath } from 'url';
import path from 'path';

const filename = fileURLToPath(import.meta.url);
const dirname = path.dirname(filename);

console.info('dirname', dirname);

const paths = {
    config: path.resolve(dirname, './config.json'),
    csproj: path.resolve(dirname, './src/Fingerprint.ServerSdk/Fingerprint.ServerSdk.csproj'),
}

console.info('paths', paths);

function bumpConfigVersion(version) {
    config.packageVersion = version;

    fs.writeFileSync(paths.config, JSON.stringify(config, null, 4));
}

function bumpCsprojVersion(version) {
    const csproj = fs.readFileSync(paths.csproj, 'utf8');

    // Replace <Version> tag with given version
    const newCsproj = csproj.replace(/<Version>.*<\/Version>/, `<Version>${version}</Version>`);

    console.info('newCsproj', newCsproj);

    fs.writeFileSync(paths.csproj, newCsproj);
}

const version = pkg.version

bumpConfigVersion(version);
bumpCsprojVersion(version);
